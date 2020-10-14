#region Copyright Syncfusion Inc. 2001 - 2020
//
//  Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System.IO;
using Newtonsoft.Json;

namespace Financology.Watchlist
{
    public partial class Watchlist : RibbonForm
    {
        #region [private Variables ]
        Panel TabBarPane = new Panel();
        #endregion

        #region [Constructor]
        public Watchlist()
        {
            InitializeComponent();
            this.excelRibbon.RibbonStyle = RibbonStyle.Office2013;
            try
            {
                System.Drawing.Icon ico = new System.Drawing.Icon(GetIconFile(@"Common\Images\Grid\Icon\sficon.ico"));
                this.Icon = ico;
            }
            catch { }

            this.BackStageInitializeComponent();
            this.backStageView1.HostForm = this;
            this.excelRibbon.BackStageView = this.backStageView1;
        }
        #endregion

        #region Form Icon
        private string GetIconFile(string bitmapName)
        {
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(bitmapName))
                    return bitmapName;

                bitmapName = @"..\" + bitmapName;
            }

            return bitmapName;
        }
        #endregion


        #region[Form Load]
        private void Watchlist_Load(object sender, EventArgs e)
        {
            #region [WorkBook]
            // Create a new child
            WorkBook workBook = new WorkBook(this);
            this.workBook = workBook;
            Panel BackPanel = new Panel();
            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            TabBarPane.Size = new System.Drawing.Size(500, 50);

            this.columnChooser = new ColumnChooserPopup(workBook._grid);
            BackPanel.Dock = DockStyle.Fill;
            TabBarPane.Controls.Add(workBook._grid);

            workBook._grid.BringToFront();
            //workBook.tabBarSplitterControl.Dock = DockStyle.Fill;

            TabBarPane.BringToFront();
            TabBarPane.Dock = DockStyle.Fill;
            BackPanel.Dock = DockStyle.Fill;
            this.Controls.Add(BackPanel);
            BackPanel.Controls.Add(TabBarPane);

            //this.workBook.tabBarSplitterControl.EnableOffice2013Style = true;
            //this.workBook.tabBarSplitterControl.ShowAddNewTabBarPageOption = true;
            //this.workBook.tabBarSplitterControl.Style = TabBarSplitterStyle.Metro;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    MdiClient mdiClient = (MdiClient)ctrl;
                    mdiClient.BackColor = Color.FromArgb(165, 195, 239);
                }
            }
            #endregion
            this.FormClosing += Watchlist_FormClosing;
        }

        private void Watchlist_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.backStageView1.HostForm.Close();
        }
        #endregion

        #region [BackStage]
        private void BackStageInitializeComponent()
        {
            this.backStageView1 = new Syncfusion.Windows.Forms.BackStageView(this.components);
            this.backStage1 = new Syncfusion.Windows.Forms.BackStage();
            this.saveBackStageButton = new Syncfusion.Windows.Forms.BackStageButton();
            this.openBackStageButton = new Syncfusion.Windows.Forms.BackStageButton();
            this.exitBackStageButton = new Syncfusion.Windows.Forms.BackStageButton();
            //newTabPanel = new NewTabPanel();
            ((System.ComponentModel.ISupportInitialize)(this.backStage1)).BeginInit();
            this.backStage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backStageView1
            // 
            this.backStageView1.BackStage = this.backStage1;
            this.backStageView1.HostControl = null;
            // 
            // backStage1
            // 
            this.backStage1.AllowDrop = true;
            this.backStage1.BeforeTouchSize = new System.Drawing.Size(715, 449);
            this.backStage1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.backStage1.Controls.Add(this.openBackStageButton);
            this.backStage1.Controls.Add(this.saveBackStageButton);
            this.backStage1.Controls.Add(this.exitBackStageButton);
            this.backStage1.ItemSize = new System.Drawing.Size(138, 40);
            this.backStage1.Location = new System.Drawing.Point(1, 51);
            this.backStage1.Name = "backStage1";
            this.backStage1.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Blue;
            this.backStage1.Size = new System.Drawing.Size(715, 449);
            this.backStage1.TabIndex = 4;
            // 
            // saveBackStageButton
            // 
            this.saveBackStageButton.Accelerator = "";
            this.saveBackStageButton.BackColor = System.Drawing.Color.Transparent;
            this.saveBackStageButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.saveBackStageButton.IsBackStageButton = false;
            this.saveBackStageButton.Location = new System.Drawing.Point(0, 53);
            this.saveBackStageButton.Name = "saveBackStageButton";
            this.saveBackStageButton.Size = new System.Drawing.Size(137, 38);
            this.saveBackStageButton.TabIndex = 4;
            this.saveBackStageButton.Text = "Save";
            this.saveBackStageButton.Click += saveAsBackStageButton_Click;

            // 
            // openBackStageButton
            // 
            this.openBackStageButton.Accelerator = "";
            this.openBackStageButton.BackColor = System.Drawing.Color.Transparent;
            this.openBackStageButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.openBackStageButton.IsBackStageButton = false;
            this.openBackStageButton.Location = new System.Drawing.Point(0, 53);
            this.openBackStageButton.Name = "openBackStageButton";
            this.openBackStageButton.Size = new System.Drawing.Size(137, 38);
            this.openBackStageButton.TabIndex = 4;
            this.openBackStageButton.Text = "Open";
            this.openBackStageButton.Click += openBackStageButton_Click;
            // 
            // exitBackStageButton
            // 
            this.exitBackStageButton.Accelerator = "";
            this.exitBackStageButton.BackColor = System.Drawing.Color.Transparent;
            this.exitBackStageButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.exitBackStageButton.IsBackStageButton = false;
            this.exitBackStageButton.Location = new System.Drawing.Point(0, 53);
            this.exitBackStageButton.Name = "exitBackStageButton";
            this.exitBackStageButton.Size = new System.Drawing.Size(137, 38);
            this.exitBackStageButton.TabIndex = 4;
            this.MinimumSize = new Size(867, 679);
            this.exitBackStageButton.Text = "Exit";
            this.exitBackStageButton.Click += new EventHandler(exitBackStageButton_Click);
            // 
            // 
            // 
            ((System.ComponentModel.ISupportInitialize)(this.backStage1)).EndInit();
            this.backStage1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        #region [Events]

        private void ChooserButton_Click(object sender, EventArgs e)
        {
            this.columnChooser.ShowDialog();
            this.chooserButton.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(symbolBox.Text))
                MessageBox.Show("Please enter a valid symbol");
            else
            {
                DataManager.instance.AddSymbol(symbolBox.Text);
                symbolBox.Text = string.Empty;
            }
        }

        void openBackStageButton_Click(object sender, EventArgs e)
        {
            //Syncfusion.GridExcelConverter.GridExcelConverterControl gecc = new Syncfusion.GridExcelConverter.GridExcelConverterControl();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files(*.xlsx)|*.xlsx";
            openFileDialog.DefaultExt = ".xlsx";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    gecc.ExcelToGrid(openFileDialog.FileName, this.workBook._grid.Model);

            this.workBook._grid.Refresh();
            this.backStageView1.BackStage.Visible = false;
        }

        void saveAsBackStageButton_Click(object sender, EventArgs e)
        {
            //Syncfusion.GridExcelConverter.GridExcelConverterControl gecc = new Syncfusion.GridExcelConverter.GridExcelConverterControl();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files(*.xlsx)|*.xlsx|Files(*.xls)|*.xls";
            saveFileDialog.DefaultExt = ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //gecc.GridToExcel(this.workBook._grid.Model, saveFileDialog.FileName);

                if (MessageBox.Show("Do you wish to open the xls file now?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = saveFileDialog.FileName;
                    proc.Start();
                }
            }
            this.backStageView1.BackStage.Visible = false;
        }

        void exitBackStageButton_Click(object sender, EventArgs e)
        {
            this.backStageView1.HostForm.Close();
        }

        void redoBtn_Click(object sender, EventArgs e)
        {
            //if (!this.workBook._grid.CommandStack.InTransaction)
            //{
            //    this.workBook._grid.CommandStack.Redo();
            //}
        }

        void undoBtn_Click(object sender, EventArgs e)
        {
            //if (!this.workBook._grid.CommandStack.InTransaction)
            //{
            //    this.workBook._grid.CommandStack.Undo();
            //}
        }

        void saveBtn_Click(object sender, EventArgs e)
        {
            //Syncfusion.GridExcelConverter.GridExcelConverterControl gecc = new Syncfusion.GridExcelConverter.GridExcelConverterControl();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files(*.xlsx)|*.xlsx|Files(*.xls)|*.xls";
            saveFileDialog.DefaultExt = ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //gecc.GridToExcel(this.workBook._grid.Model, saveFileDialog.FileName);

                if (MessageBox.Show("Do you wish to open the xls file now?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = saveFileDialog.FileName;
                    proc.Start();
                }
            }
        }


        #endregion
    }
}
