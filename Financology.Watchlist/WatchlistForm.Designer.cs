using Syncfusion.WinForms.Controls;
using System.Drawing;

namespace Financology.Watchlist
{
    partial class WatchlistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchlistForm));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topSectionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.symbolTextBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.columnChooserButton = new Syncfusion.WinForms.Controls.SfButton();
            this.addSymbolbutton = new Syncfusion.WinForms.Controls.SfButton();
            this.gridTabControl = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.mainTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.statusBar = new Syncfusion.Windows.Forms.Tools.StatusBarAdv();
            this.dataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.addTabButton = new Syncfusion.WinForms.Controls.SfButton();
            this.mainLayoutPanel.SuspendLayout();
            this.topSectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTabControl)).BeginInit();
            this.gridTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.topSectionPanel);
            this.mainLayoutPanel.Controls.Add(this.gridTabControl);
            this.mainLayoutPanel.Controls.Add(this.statusBar);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(2, 2);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 3;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(796, 446);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // topSectionPanel
            // 
            this.topSectionPanel.ColumnCount = 4;
            this.topSectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.topSectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.topSectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.topSectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.topSectionPanel.Controls.Add(this.symbolTextBox, 0, 1);
            this.topSectionPanel.Controls.Add(this.columnChooserButton, 3, 0);
            this.topSectionPanel.Controls.Add(this.addSymbolbutton, 1, 1);
            this.topSectionPanel.Controls.Add(this.addTabButton, 0, 0);
            this.topSectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSectionPanel.Location = new System.Drawing.Point(3, 3);
            this.topSectionPanel.Name = "topSectionPanel";
            this.topSectionPanel.RowCount = 2;
            this.topSectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topSectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topSectionPanel.Size = new System.Drawing.Size(790, 47);
            this.topSectionPanel.TabIndex = 0;
            // 
            // symbolTextBox
            // 
            this.symbolTextBox.BeforeTouchSize = new System.Drawing.Size(191, 20);
            this.symbolTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.symbolTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbolTextBox.Location = new System.Drawing.Point(3, 26);
            this.symbolTextBox.Name = "symbolTextBox";
            this.symbolTextBox.Size = new System.Drawing.Size(191, 20);
            this.symbolTextBox.TabIndex = 0;
            // 
            // columnChooserButton
            // 
            this.columnChooserButton.AccessibleName = "Button";
            this.columnChooserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.columnChooserButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.columnChooserButton.Location = new System.Drawing.Point(683, 3);
            this.columnChooserButton.Name = "columnChooserButton";
            this.columnChooserButton.Size = new System.Drawing.Size(104, 17);
            this.columnChooserButton.TabIndex = 2;
            this.columnChooserButton.Text = "Column Chooser";
            // 
            // addSymbolbutton
            // 
            this.addSymbolbutton.AccessibleName = "Button";
            this.addSymbolbutton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.addSymbolbutton.Location = new System.Drawing.Point(200, 26);
            this.addSymbolbutton.Name = "addSymbolbutton";
            this.addSymbolbutton.Size = new System.Drawing.Size(104, 18);
            this.addSymbolbutton.TabIndex = 3;
            this.addSymbolbutton.Text = "Add Symbol";
            this.addSymbolbutton.Click += new System.EventHandler(this.addSymbolbutton_Click);
            // 
            // gridTabControl
            // 
            this.gridTabControl.ActiveTabForeColor = Color.White;
            this.gridTabControl.InActiveTabForeColor = Color.GhostWhite;
            this.gridTabControl.BeforeTouchSize = new System.Drawing.Size(790, 368);
            this.gridTabControl.Controls.Add(this.mainTab);
            this.gridTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTabControl.Location = new System.Drawing.Point(3, 56);
            this.gridTabControl.Name = "gridTabControl";
            this.gridTabControl.Size = new System.Drawing.Size(790, 368);
            this.gridTabControl.TabIndex = 1;
            // 
            // mainTab
            // 
            this.mainTab.Image = null;
            this.mainTab.ImageSize = new System.Drawing.Size(16, 16);
            this.mainTab.Location = new System.Drawing.Point(1, 25);
            this.mainTab.Name = "mainTab";
            this.mainTab.ShowCloseButton = true;
            this.mainTab.Size = new System.Drawing.Size(787, 341);
            this.mainTab.TabIndex = 1;
            this.mainTab.Text = "Main";
            this.mainTab.ThemesEnabled = false;
            // 
            // statusBar
            // 
            this.statusBar.BeforeTouchSize = new System.Drawing.Size(790, 13);
            this.statusBar.CustomLayoutBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.Location = new System.Drawing.Point(3, 430);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(3);
            this.statusBar.Size = new System.Drawing.Size(790, 13);
            this.statusBar.Spacing = new System.Drawing.Size(2, 2);
            this.statusBar.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleName = "Table";
            this.dataGrid.AllowEditing = false;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(791, 345);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.Text = "dataGrid";
            // 
            // addTabButton
            // 
            this.addTabButton.AccessibleName = "Button";
            this.addTabButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.addTabButton.Location = new System.Drawing.Point(3, 3);
            this.addTabButton.Name = "addTabButton";
            this.addTabButton.Size = new System.Drawing.Size(79, 17);
            this.addTabButton.TabIndex = 4;
            this.addTabButton.Text = "Add Tab";
            // 
            // WatchlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WatchlistForm";
            this.Style.BackColor = System.Drawing.Color.Black;
            this.Style.ForeColor = System.Drawing.Color.White;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Style.TitleBar.BackColor = System.Drawing.Color.Black;
            this.Style.TitleBar.CloseButtonForeColor = System.Drawing.Color.White;
            this.Style.TitleBar.CloseButtonHoverBackColor = System.Drawing.Color.DarkGray;
            this.Style.TitleBar.CloseButtonPressedBackColor = System.Drawing.Color.Gray;
            this.Style.TitleBar.ForeColor = System.Drawing.Color.White;
            this.Style.TitleBar.MaximizeButtonForeColor = System.Drawing.Color.White;
            this.Style.TitleBar.MaximizeButtonHoverBackColor = System.Drawing.Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonPressedBackColor = System.Drawing.Color.Gray;
            this.Style.TitleBar.MinimizeButtonForeColor = System.Drawing.Color.White;
            this.Style.TitleBar.MinimizeButtonHoverBackColor = System.Drawing.Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonPressedBackColor = System.Drawing.Color.Gray;
            this.Style.TitleBar.TextHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text = "Watchlist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainLayoutPanel.ResumeLayout(false);
            this.topSectionPanel.ResumeLayout(false);
            this.topSectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTabControl)).EndInit();
            this.gridTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel topSectionPanel;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv gridTabControl;
        private Syncfusion.Windows.Forms.Tools.StatusBarAdv statusBar;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv mainTab;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dataGrid;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt symbolTextBox;
        private SfButton columnChooserButton;
        private SfButton addSymbolbutton;
        private SfButton addTabButton;
    }
}

