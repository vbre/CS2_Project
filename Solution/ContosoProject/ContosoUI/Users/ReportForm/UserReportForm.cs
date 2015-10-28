﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ContosoUI.Users.Edit;

namespace ContosoUI.EditUserForm
{
    public partial class UserReportForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UserReportPresenter presenter;
        public UserReportForm()
        {
            InitializeComponent();
            presenter = new UserReportPresenter(this);
        }

        public override void Refresh()
        {
            UserReportGridControl.DataSource = presenter.ViewModels;
            UserReportGridControl.Refresh();
        }

        private void userReportViewModelBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void UserReportGridView_DoubleClick(object sender, EventArgs e)
        {
            if (Program.AuthUser.Role.Permissions.Any(x=> x.Type == Domain.PermissionType.EditUser))
            {
                var grid = (GridView)sender;
                GridHitInfo info = grid.CalcHitInfo(grid.GridControl.PointToClient(Control.MousePosition));

                var id = grid.GetRowCellValue(info.RowHandle, "Id");
                if (id != null)
                {
                    var form = new UserEditForm((int)id);
                    form.MdiParent = this.MdiParent;
                    form.Show();
                }
            }
        }
    }
}