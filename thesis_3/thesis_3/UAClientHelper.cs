using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace thesis_3
{
    public class UAClientHelper
    {
        #region Construction
        public UAClientHelper()
        {
            // creates the application configuration ( containing the certificate) on construction
            mApplicationConfig = CreateClientConfig();
        }


        #endregion
        #region Properties
        // keep a session with OPC UA sever
        private Session mSession = null;

        // specifies this application
        private ApplicationConfiguration mApplicationConfig = null;

        // provide client cert
        public X509Certificate clientcertificate = null;

        // provide evnet handle the cert

        public CertificateValidationEventHandler certificateValidationEventHandler = null;
        // provide the session with sever
        public Session Session
        {
            get { return mSession;  }
        }

        /// the number of second between connect and reconnect

        public int ReconnectPeriod { get; set; } = 10;

        /// provide the event for the value changes of a monitored items
        public MonitoredItemNotificationEventHandler ItemChangeNotification = null;

        /// Provides the event for KeepAliveNotifications.
        public KeepAliveEventHandler Alivenotification = null;


        /// Provides the event for a monitored event item.
        public NotificationEventHandler ItemEventhandler = null;
        #endregion

        #region Connection
        public ApplicationDescriptionCollection FindServers(string url)
        {
            Uri uri = new Uri(url);

            DiscoveryClient client = DiscoveryClient.Create(uri);
            // find server
            ApplicationDescriptionCollection servers = client.FindServers(null);
            client.Close();
            client.Dispose();
            return servers;
        }

        public EndpointDescriptionCollection Endpoint(string severUrl)
        {
            Uri uri = new Uri(severUrl);

            DiscoveryClient client = DiscoveryClient.Create(uri);
            EndpointDescriptionCollection endpoints = client.GetEndpoints(null);
            client.Close();
            client.Dispose();
            return endpoints;

        }
        /// <summary>
        /// establishes the connection to an OPC UA servers and creates a session using an EndpointDescription
        /// </summary>
        /// <param name="endpointDescription"></param>
        /// <param name="userAuth"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task Connect ( EndpointDescription endpointDescription, bool userAuth, string userName, string password)
        {
            // specify application configuaration
            ApplicationConfiguration applicationConfiguration = mApplicationConfig;
            Console.WriteLine("6");

            // get client cert
            clientcertificate = await applicationConfiguration.SecurityConfiguration.ApplicationCertificate.Find(true).ConfigureAwait(false);
            Console.WriteLine("7");
            // function for a cert event 
            mApplicationConfig.CertificateValidator.CertificateValidation += CertificateValidator_CertificateValidation;
            Console.WriteLine("8");
            // create e ndpoint configuration
            EndpointConfiguration endpointcofig = EndpointConfiguration.Create(applicationConfiguration);
            Console.WriteLine("9");
            // connect to sever and get endpoint
            ConfiguredEndpoint mEndpoint = new ConfiguredEndpoint(null, endpointDescription, endpointcofig);
            Console.WriteLine("10");
            // session name 
            string sessionName = "MySession";



            Console.WriteLine("11");
            // create user identity
            UserIdentity userIdentity;
            if (userAuth)
            {
                userIdentity = new UserIdentity(userName, password);
            }
            else
            {
                userIdentity = new UserIdentity();
            }
            // update crtificate store before connecting 
            await applicationConfiguration.CertificateValidator.Update(applicationConfiguration);
            Console.WriteLine("11.5");
            // create  connect

            mSession = await Session.Create(
                applicationConfiguration,
                mEndpoint,
                true,
                sessionName,
                60000,
                userIdentity,
                null);

            Console.WriteLine("11.6");
            mSession.KeepAlive += new KeepAliveEventHandler( MSession_KeepAlive);
            Console.WriteLine("12");

            // disconect
            

            #endregion
        }



        public void Disconnect()
        {
            if (mSession != null)
            {
                mSession.Close(10000);
                mSession.Dispose();
            }
        }
        #region Namespace
        // return the namcespace uri at the specific index
        public string GetNamespace(uint index)
        {
            if(mSession.NamespaceUris.Count > index)
            {
                return mSession.NamespaceUris.GetString(index);
            }
            else
            {
                Exception e = new Exception("index out of range ");
                throw e;
            }
        }
        // return the index of the specific namespace 
        public uint GetNamespaceIndex( string url)
        {
            // get the namespace index of specific uri
            int namespaceIndex = mSession.NamespaceUris.GetIndex(url);
            // if the namespace url doesnt exisit, namespace index -1 
            if ( namespaceIndex >= 0)
            {
                return (uint)namespaceIndex;
            }
            else
            {
                Exception ex = new Exception("Namespace doesnt exisit");
                throw ex;
            }
        }
        //  return a list of all namespaceuri 
        public List<string> GetNamespaceArray()
        {
            List<string> NamespaceArray = new List<string>();
            // read all namespace uri
            for( uint i = 1; i< mSession.NamespaceUris.Count; i++)
            {
                NamespaceArray.Add(mSession.NamespaceUris.GetString(i));
            }
            return NamespaceArray;
        }

        #endregion
        #region Browse 
        // show description -> browse nodeID which provided by referDis
        // browse the root folder of an OPC UA server
        // ReferenceDescriptionCollection of found nodes
        public ReferenceDescriptionCollection BrowseRoot()
        {
            // create a collection for the browse result
            ReferenceDescriptionCollection referenceDescriptionCollection;
            // create a continuationPoint
            byte[] continuationPiont;
            mSession.Browse(null, null, ObjectIds.RootFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out continuationPiont, out referenceDescriptionCollection);
            return referenceDescriptionCollection;
        }
        public ReferenceDescriptionCollection BrowseNode( ReferenceDescription refDes)
        {
            // create a collection for the browse result 
            ReferenceDescriptionCollection referenceDescriptionsCollection;
            ReferenceDescriptionCollection nextReferenceDescriptionCollection;
            byte[] continuationPoint;   
            byte[] ReviseContinuationPoint;
            // create a NodeId using the selected ReferenceDescription as browsing point
            NodeId nodeid = ExpandedNodeId.ToNodeId(refDes.NodeId, null);
            //browse form starting point for all objectec types
            mSession.Browse(null, null, nodeid, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true,0, out continuationPoint, out referenceDescriptionsCollection);
            while (continuationPoint != null)
            {
                mSession.BrowseNext(null, false, continuationPoint, out ReviseContinuationPoint, out nextReferenceDescriptionCollection);
                referenceDescriptionsCollection.AddRange(nextReferenceDescriptionCollection);
                continuationPoint = ReviseContinuationPoint;
            }
            return referenceDescriptionsCollection;
        }
        public NodeId getParentsNode( NodeId nodeId)
        {
            ReferenceDescriptionCollection referenceDescriptionCollection;
            byte[] continuationPoint;
            mSession.Browse(null, null, nodeId, 1, BrowseDirection.Inverse, ReferenceTypeIds.HierarchicalReferences, true, 0, out continuationPoint, out referenceDescriptionCollection);
            return ExpandedNodeId.ToNodeId(referenceDescriptionCollection[0].NodeId, null);
        }
        public ReferenceDescriptionCollection BrowseNodebyReferenceType( ReferenceDescription refDes, BrowseDirection browseDirection, NodeId reftypeID)
        {
            // create the collection for the browse result
            ReferenceDescriptionCollection referenceDescriptionsCollection;
            ReferenceDescriptionCollection nextreferenceDescriptionCollection;
            // create continiuation Point
            byte[] continuationPoint;
            byte[] revisecontiniuationPoint;
            // create NOdeid using referenceDes as browsing starting point 
            NodeId noideID = ExpandedNodeId.ToNodeId(refDes.NodeId, null);
            // browse from the starting point for all object 
            mSession.Browse(null, null, noideID, 0u, browseDirection, reftypeID, true, 0, out continuationPoint, out referenceDescriptionsCollection);
            while ( continuationPoint != null)
            {
                mSession.BrowseNext(null, false, continuationPoint, out revisecontiniuationPoint, out nextreferenceDescriptionCollection);
                referenceDescriptionsCollection.AddRange(nextreferenceDescriptionCollection);
                continuationPoint = revisecontiniuationPoint;                            
            }
            return referenceDescriptionsCollection;
        }

        #endregion
        #region Read/Write

        public Node ReadNode( string NodeIDString)
        {
            // create nodeid using the identifier string 
            NodeId nodeid = new NodeId(NodeIDString);
            // create node ]
            Node node = new Node();
            // readvalue 
            node = mSession.ReadNode(nodeid);
            return node;
        }
        // a dictionary contain the attribute vavlue of the node using the attribute uint identifer as key
        public Dictionary<uint, DataValue> ReadNodeAttribute(string NodeIDString)
        {
            Dictionary<int, uint> attributeDictionary = new Dictionary<int, uint>()
            {
                {1, Attributes.NodeId },
                {2, Attributes.NodeClass },
                {3, Attributes.BrowseName },
                {4, Attributes.DisplayName },
                {5, Attributes.Value },
                {6, Attributes.DataType },
                {7, Attributes.ValueRank },
                {8, Attributes.ArrayDimensions },
                {9, Attributes.AccessLevel },
            };
            // create a nodeID using the identifier string
            NodeId nodeid = new NodeId(NodeIDString);

            // create a read value id colleciton to store the nodes to read 
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            // create a StatusCodeCollection 
            DataValueCollection datavaluecollection = new DataValueCollection();

            //Create a diagnosticInforCollection
            DiagnosticInfoCollection diag = new DiagnosticInfoCollection();

            // go through the attribute dictionary and create the node accordingly
            for (int i = 0; i< attributeDictionary.Count; i++)
            {
                // create the read value id  with the necessary
                ReadValueId nodetoRead = new ReadValueId();
                nodetoRead.NodeId = nodeid;
                nodetoRead.AttributeId = attributeDictionary[i + 1];
                nodesToRead.Add(nodetoRead);
            }
            // read the value id collection
            mSession.Read(null, 0, TimestampsToReturn.Neither, nodesToRead, out datavaluecollection, out diag);
            // create  a dictionary to store the attribute
            Dictionary<uint, DataValue> attributeValues = new Dictionary<uint, DataValue>();
            // go through the data value collection to store every data value according to its attribute identifier
            int counter = 1;
            foreach( DataValue dataValue in datavaluecollection)
            {
                attributeValues.Add(attributeDictionary[counter], dataValue);
                counter += 1;
            }
            return attributeValues;

        }
        public List <string> Readvalue (List<string> nodeIDTString)
        {
            List<NodeId> nodeIDs = new List<NodeId>();
            List<Type> types = new List<Type>();
            List<Object> values;
            List<ServiceResult> serviceResults;
            foreach( string str in nodeIDTString)
            {
                //Create a nodeId using the identifier string and add to list
                nodeIDs.Add(new NodeId(str));
                //No need for types
                types.Add(null);
            }
            // read the data Values
            mSession.ReadValues(nodeIDs, types, out values, out serviceResults);
            // check the service 
            foreach( ServiceResult svResult in serviceResults)
            {
                if(svResult.ToLongString() != "Good")
                {
                    Exception e = new Exception(svResult.ToString());
                    throw e;
                }
            }
            //create resuly string
            List<string> resultString = new List<string>();
            foreach( object result in values)
            {
                if(result != null)
                {
                    // check if result is an array or base date type 
                    if (result is Array)
                    {
                        List<string> elements = new List<string>();
                        foreach( var elementResult in result as Array)
                        {
                            elements.Add(elementResult is byte ? ((byte)elementResult).ToString("X2") : elementResult.ToString());
                        }
                        resultString.Add(string.Join("\0", elements));
                    }
                    else // the result is scalar
                    {
                        resultString.Add(result.ToString());
                    }
                }
                else
                {
                    resultString.Add("(null)");
                }
            }
            return resultString;
        }
        // write value to node ID 
        public void WriteVlues( Dictionary<NodeId, IEnumerable<string>> valueByNodeID)
        {
            WriteValueCollection wrvalueCollection = new WriteValueCollection();
            foreach ( var keyValuePair in valueByNodeID)
            {
                NodeId nodeID = keyValuePair.Key;
                IEnumerable<string> values = keyValuePair.Value;
                // Get the OPC UA data type and the rank 
                Node node = mSession.ReadNode(nodeID);
                VariableNode variableNode = (VariableNode)node.DataLock;//
                NodeId dataTypeID = variableNode.DataType;
                BuiltInType targettype = TypeInfo.GetBuiltInType(dataTypeID);

                // Ensure that target type is not null by reading the node of the data type 
                if (targettype == BuiltInType.Null)
                {
                    try
                    {
                        // Get the node id of parent  base data type 
                        NodeId tempNodeID = GetParentDataType(dataTypeID, mSession);
                        targettype = TypeInfo.GetBuiltInType(tempNodeID);
                        if (targettype != BuiltInType.Null)// ensure that the entered node id  is not type of struct
                        {
                            throw new Exception("The entered node id may be of type struct. Please use the methods for read/write structs.");
                        }
                    }
                    catch 
                    {
                        throw new Exception("The node id data type is not castable. Please check the data type.");
                    }
                }
                int valuerank = variableNode.ValueRank;
                DataValue dataValue = null;
                //check if  there is value entered 
                if (!values.Any() || nodeID == null) // no value in tbx 
                {
                    throw new Exception(" there is no NodeID or value entered");

                }
                // ensure that boolean entries has lower case initial  and float, double, long double have the right format 
                List<string> tempvalues = new List <string>();
                if (targettype == BuiltInType.Boolean)
                {
                    foreach (string tempValue in values)
                    {
                        tempvalues.Add(tempValue.ToLower());
                    }
                    values = tempvalues;
                }
                if (targettype == BuiltInType.Float || targettype == BuiltInType.Double)
                {
                    foreach (string tempValue in values)
                    {
                        tempvalues.Add(tempValue.Replace(",", "."));
                    }
                    values = tempvalues;
                }
                try// Scalar types
                {
                    dataValue = new DataValue(new Variant(TypeInfo.Cast(values.First(), targettype)));
                }
                catch // no OPC UA data types
                {
                    throw new Exception($" the value inputed [{values.First()}] is not convertable to type of [{targettype}]");
                }
                // create a Write value using the NodeID, datatype and AttributeType
                WriteValue writeValue = new WriteValue()
                {
                    Value = dataValue,
                    NodeId = nodeID,
                    AttributeId = Attributes.Value,

                };
                // Add the dataValue to the collection
                wrvalueCollection.Add(writeValue);
            }
            StatusCodeCollection resultCode;
            // write the collection to the server
            mSession.Write(null, wrvalueCollection, out resultCode, out _);
            foreach( StatusCode code in resultCode)
            {
                if(code  != 0)
                {
                    throw new Exception(code.ToString());
                }
            }
            MessageBox.Show("value written successfully.", "Success");
            
        }
        #endregion






















        #region Eventhandling
        private void MSession_KeepAlive(ISession session, KeepAliveEventArgs e)
        {
            MSession_KeepAlive(session, e);
        }
        private void CertificateValidator_CertificateValidation(CertificateValidator certificate, CertificateValidationEventArgs e)
        {
            
            certificateValidationEventHandler(certificate, e);
        }

        #endregion

        #region Private method
        // Handle a reconnect event from a neconnect handle
        private void GetmethodInformation(NodeId methodID, out List<NodeId> dataTypeIDs, out List<int> valueRanks)
        {
            ReferenceDescriptionCollection referenceDescriptionsCollection;
            // create continuaPoint
            byte[] continuationPoint;

            mSession.Browse(
                null,
                null,
                methodID,
                0u,
                BrowseDirection.Forward,
                ReferenceTypeIds.HierarchicalReferences,
                true,
                0,
                out continuationPoint,
                out referenceDescriptionsCollection
                );
            List<NodeId> nodeIdInputArguement = new List<NodeId>();
            List<Type> types = new List<Type>();
            foreach( ReferenceDescription refdes in referenceDescriptionsCollection)
            {
                if (refdes.BrowseName == " InputArguement")
                {
                    nodeIdInputArguement.Add(new NodeId(refdes.NodeId.ToString()));
                    types.Add(null);
                }
            }
            List<object> inputValues = new List<object>();
            List<ServiceResult> serviceResults = new List<ServiceResult>();
            dataTypeIDs = new List<NodeId>();
            valueRanks = new List<int>();
            // read the input/output argurement
            mSession.ReadValues(nodeIdInputArguement, types, out inputValues, out serviceResults);
            foreach( object result in inputValues)
            {
                // cast object to Extantion object  becasue input and output arguement are always extention object
                ExtensionObject encodeable = result as ExtensionObject;
                if(encodeable == null)
                {
                    ExtensionObject[] exObjarray = result as ExtensionObject[];
                    foreach(ExtensionObject exOb in exObjarray)
                    {
                        // get datatype of the input 
                        Argument arg = exOb.Body as Argument;
                        dataTypeIDs.Add(arg.DataType);
                        if(arg.ArrayDimensions.Count == 0)
                        {
                            valueRanks.Add(ValueRanks.Scalar);
                        }
                    }
                }
            }




        }

        private static NodeId GetParentDataType ( NodeId nodeId, Session theSessiontoBroweIn)
        {
            ReferenceDescriptionCollection referenceDescriptionsCollection;
            byte[] continuationPoint;
            theSessiontoBroweIn.Browse(null, null, nodeId, 1, BrowseDirection.Inverse, ReferenceTypeIds.HierarchicalReferences, true , 0  , out continuationPoint, out referenceDescriptionsCollection);
            NodeId nodeIDparentsDataType = (NodeId)referenceDescriptionsCollection[0].NodeId;
            if ( nodeIDparentsDataType.NamespaceIndex != 0)
            {
                nodeIDparentsDataType = GetParentDataType(nodeIDparentsDataType, theSessiontoBroweIn);

            }
            return nodeIDparentsDataType;
        }
        private static List<string> GetLocalIpAddressAndDns()
        {
            List<string> localIps = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIps.Add(ip.ToString());
                }
            }
            if (localIps.Count == 0)
            {
                throw new Exception("Local IP Address Not Found!");
            }
            localIps.Add(Dns.GetHostName());
            return localIps;
        }
        private static void CreateCertificateAndAddToStore(string applicationUri, string applicationName, string storeType, string storePath)
        {
            List<string> localIps = GetLocalIpAddressAndDns(); // Get local interface ip addresses and DNS name
            ushort keySize = 2048; //must be multiples of 1024
            ushort lifeTimeInMonths = 24; //month till certificate expires
            ushort hashSizeInBits = 256; //0 = SHA1; 1 = SHA256
            var startTime = System.DateTime.Now; //starting point of time when certificate is valid

            var certificateBuilder = CertificateFactory.CreateCertificate(
                applicationUri,
                applicationName,
                null,
                localIps);

            X509Certificate2 clientCertificate2 = certificateBuilder
                .SetNotBefore(startTime)
                .SetNotAfter(startTime.AddMonths(lifeTimeInMonths))
                .SetHashAlgorithm(X509Utils.GetRSAHashAlgorithmName(hashSizeInBits))
                .SetRSAKeySize(keySize)
                .CreateForRSA()
                .AddToStore(
                    storeType,
                    storePath,
                    null
                );
        }
        private static ApplicationConfiguration CreateClientConfig()
        {
            // The application configuration can be loaded from any file.
            // ApplicationConfiguration.Load() method loads configuration by looking up a file path in the App.config.
            // This approach allows applications to share configuration files and to update them.
            // This example creates a minimum ApplicationConfiguration using its default constructor.
            ApplicationConfiguration config = new ApplicationConfiguration();

            // Step-1: specify the config 
            config.ApplicationName = "UA Client";
            config.ApplicationType = ApplicationType.Client;
            config.ApplicationUri = "urn:MyClient";
            config.ProductUri = "SiemensAG.IndustryOnlineSupport";
            // Step-2 : Specify the client's application instance certificate
            // application instance certificate must be placed in a windows certificate store becasue that is
            // the best way to protect private key. Certificate in a store are identified with 4 parameter:
            // Storelocation, StoreName, SubjectName and thumbprint.
            // when using storeype = directory you need to have  the opc.ua.certificate.exe in your machines
            config.SecurityConfiguration = new SecurityConfiguration();
            config.SecurityConfiguration.ApplicationCertificate = new CertificateIdentifier();
            config.SecurityConfiguration.ApplicationCertificate.StoreType = CertificateStoreType.X509Store;
            config.SecurityConfiguration.ApplicationCertificate.StorePath = "CurrentUser\\My";
            config.SecurityConfiguration.ApplicationCertificate.SubjectName = config.ApplicationName;
            config.SecurityConfiguration.AutoAcceptUntrustedCertificates = true;
            config.SecurityConfiguration.RejectSHA1SignedCertificates = false;
            // Define trusted root store for server certificate checks
            config.SecurityConfiguration.TrustedIssuerCertificates.StoreType = CertificateStoreType.X509Store;
            config.SecurityConfiguration.TrustedIssuerCertificates.StorePath = "CurrentUser\\Root";
            config.SecurityConfiguration.TrustedPeerCertificates.StoreType = CertificateStoreType.X509Store;
            config.SecurityConfiguration.TrustedPeerCertificates.StorePath = "CurrentUser\\Root";
            
            // find the client certificate in store
            Task<X509Certificate2> clientCertificate = config.SecurityConfiguration.ApplicationCertificate.Find(true);
            // create new selfsign cert if not found
            if (clientCertificate.Result == null)
            {
                CreateCertificateAndAddToStore(config.ApplicationUri, config.ApplicationName, config.SecurityConfiguration.ApplicationCertificate.StoreType, config.SecurityConfiguration.ApplicationCertificate.StorePath);
            };
            // specific the supported transport quotas
            config.TransportQuotas = new TransportQuotas();
            config.TransportQuotas.OperationTimeout = 360000;
            config.TransportQuotas.MaxArrayLength = 86400000;
            config.TransportQuotas.MaxStringLength= 67108864;
            config.TransportQuotas.MaxByteStringLength = 16777216;
            // specify the client specific config
            config.ClientConfiguration = new ClientConfiguration();
            config.ClientConfiguration.DefaultSessionTimeout = 360000;
            // Step 5 - Validate the configuration.
            // This step checks if the configuration is consistent and assigns a few internal variables
            // that are used by the SDK. This is called automatically if the configuration is loaded from
            // a file using the ApplicationConfiguration.Load() method.
            _ = config.Validate(ApplicationType.Client);
            return config;
        }
        //Create endpointdescription
        private static EndpointDescription CreateEndPointDescription( string url, string secPolicy, MessageSecurityMode msgsceMode)
        {
            // create the EndpointDescription
            EndpointDescription endpointDescription = new EndpointDescription();
            // submit the url   of the endpoint
            endpointDescription.EndpointUrl = url;
            // specify the policy to use 
            endpointDescription.SecurityPolicyUri = secPolicy;
            endpointDescription.SecurityMode = msgsceMode;
            // specify the transport profile
            endpointDescription.TransportProfileUri = Profiles.UaTcpTransport;
            return endpointDescription;
        }
        #endregion
    }

}

