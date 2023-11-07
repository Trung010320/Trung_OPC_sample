
namespace thesis_3
{
    partial class UAClientCertForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.certGridView = new System.Windows.Forms.DataGridView();
            this.permaCheckBox = new System.Windows.Forms.CheckBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.AttributeCollumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCollumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.certGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // certGridView
            // 
            this.certGridView.AllowUserToAddRows = false;
            this.certGridView.AllowUserToDeleteRows = false;
            this.certGridView.AllowUserToResizeColumns = false;
            this.certGridView.AllowUserToResizeRows = false;
            this.certGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.certGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.certGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.certGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.certGridView.CausesValidation = false;
            this.certGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.certGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.certGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeCollumn,
            this.ValueCollumn});
            this.certGridView.Location = new System.Drawing.Point(13, 13);
            this.certGridView.Margin = new System.Windows.Forms.Padding(4);
            this.certGridView.Name = "certGridView";
            this.certGridView.ReadOnly = true;
            this.certGridView.RowHeadersVisible = false;
            this.certGridView.RowHeadersWidth = 51;
            this.certGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.certGridView.RowTemplate.Height = 24;
            this.certGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.certGridView.ShowEditingIcon = false;
            this.certGridView.Size = new System.Drawing.Size(517, 463);
            this.certGridView.TabIndex = 0;
            // 
            // permaCheckBox
            // 
            this.permaCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.permaCheckBox.AutoSize = true;
            this.permaCheckBox.Location = new System.Drawing.Point(13, 483);
            this.permaCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.permaCheckBox.Name = "permaCheckBox";
            this.permaCheckBox.Size = new System.Drawing.Size(220, 21);
            this.permaCheckBox.TabIndex = 4;
            this.permaCheckBox.Text = "Accept certificate permanently";
            this.permaCheckBox.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(12, 514);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 5;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // rejectButton
            // 
            this.rejectButton.Location = new System.Drawing.Point(118, 514);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(75, 23);
            this.rejectButton.TabIndex = 5;
            this.rejectButton.Text = "Reject";
            this.rejectButton.UseVisualStyleBackColor = true;
            // 
            // AttributeCollumn
            // 
            this.AttributeCollumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AttributeCollumn.HeaderText = "Attribute";
            this.AttributeCollumn.MinimumWidth = 6;
            this.AttributeCollumn.Name = "AttributeCollumn";
            this.AttributeCollumn.ReadOnly = true;
            this.AttributeCollumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AttributeCollumn.Width = 125;
            // 
            // ValueCollumn
            // 
            this.ValueCollumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.ValueCollumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.ValueCollumn.HeaderText = "Value";
            this.ValueCollumn.MinimumWidth = 6;
            this.ValueCollumn.Name = "ValueCollumn";
            this.ValueCollumn.ReadOnly = true;
            this.ValueCollumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UAClientCertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 549);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.permaCheckBox);
            this.Controls.Add(this.certGridView);
            this.Name = "UAClientCertForm";
            this.Text = "UACertificate";
            ((System.ComponentModel.ISupportInitialize)(this.certGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView certGridView;
        private System.Windows.Forms.CheckBox permaCheckBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeCollumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCollumn;
    }
}