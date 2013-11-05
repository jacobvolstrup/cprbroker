﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The CPR Broker concept was initally developed by
 * Gentofte Kommune / Municipality of Gentofte, Denmark.
 * Contributor(s):
 * Steen Deth
 *
 *
 * The Initial Code for CPR Broker and related components is made in
 * cooperation between Magenta, Gentofte Kommune and IT- og Telestyrelsen /
 * Danish National IT and Telecom Agency
 *
 * Contributor(s):
 * Beemen Beshara
 * Niels Elgaard Larsen
 * Leif Lodahl
 * Steen Deth
 *
 * The code is currently governed by IT- og Telestyrelsen / Danish National
 * IT and Telecom Agency
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CprBroker.Installers
{
    /// <summary>
    /// Gets the system's database information from the user
    /// </summary>
    public partial class DatabaseForm : BaseForm
    {
        public DatabaseForm()
        {
            InitializeComponent();
            SetupInfo = new DatabaseSetupInfo();
        }
        public DatabaseSetupInfo SetupInfo { get; set; }

        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            // Initialize contents
            adminLoginInfo.AuthenticationInfo = SetupInfo.AdminAuthenticationInfo;
            applicationLoginInfo.AuthenticationInfo = SetupInfo.ApplicationAuthenticationInfo;
            serverNameTextBox.Text = SetupInfo.ServerName;
            databaseNameTextBox.Text = SetupInfo.DatabaseName;
            sameAsAdminCheckBox.Checked = SetupInfo.ApplicationAuthenticationSameAsAdmin;
        }

        private void serverNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetupInfo.ServerName = serverNameTextBox.Text;
        }

        private void databaseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetupInfo.DatabaseName = databaseNameTextBox.Text;
        }

        private void sameAsAdminCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetupInfo.ApplicationAuthenticationSameAsAdmin = sameAsAdminCheckBox.Checked;
            applicationLoginInfo.Enabled = !sameAsAdminCheckBox.Checked;
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                TestInformation(true);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            CloseAsOK();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool TestInformation(bool showSuccess)
        {
            string message = "";
            bool result = SetupInfo.Validate(ref message);
            if (!result)
            {
                MessageBox.Show(message, Messages.Unsuccessful, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (showSuccess)
            {
                MessageBox.Show(Messages.Succeeded, Messages.Succeeded, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return result;
        }

        protected override bool ValidateContents()
        {
            return base.ValidateContents() && TestInformation(false);
        }

    }
}