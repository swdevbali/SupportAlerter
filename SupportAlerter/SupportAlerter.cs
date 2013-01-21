using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using OpenPop.Common.Logging;
using Message = OpenPop.Mime.Message;
namespace SupportAlerter
{
    public partial class SupportAlerter : Form
    {
        private readonly Pop3Client pop3Client;
        private readonly Dictionary<int, Message> messages = new Dictionary<int, Message>();
        public SupportAlerter()
        {
            pop3Client = new Pop3Client();

            InitializeComponent();
        }

        private void connectAndRetrieveButton_Click(object sender, EventArgs e)
        {
            ReceiveMails();
        }

        /*helper*/
        private void ReceiveMails()
        {
            // Disable buttons while working
            connectAndRetrieveButton.Enabled = false;
            uidlButton.Enabled = false;
            progressBar.Value = 0;

            try
            {
                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                pop3Client.Connect(popServerTextBox.Text, int.Parse(portTextBox.Text), useSslCheckBox.Checked);
                pop3Client.Authenticate(loginTextBox.Text, passwordTextBox.Text);
                int count = pop3Client.GetMessageCount();
                totalMessagesTextBox.Text = count.ToString();
                messageTextBox.Text = "";
                messages.Clear();
                listMessages.Nodes.Clear();
                listAttachments.Nodes.Clear();

                int success = 0;
                int fail = 0;
                for (int i = count; i >= 1; i -= 1)
                {
                    // Check if the form is closed while we are working. If so, abort
                    if (IsDisposed)
                        return;

                    // Refresh the form while fetching emails
                    // This will fix the "Application is not responding" problem
                    Application.DoEvents();

                    try
                    {
                        Message message = pop3Client.GetMessage(i);

                        // Add the message to the dictionary from the messageNumber to the Message
                        messages.Add(i, message);

                        // Create a TreeNode tree that mimics the Message hierarchy
                        TreeNode node = new TreeNodeBuilder().VisitMessage(message);

                        // Set the Tag property to the messageNumber
                        // We can use this to find the Message again later
                        node.Tag = i;

                        // Show the built node in our list of messages
                        listMessages.Nodes.Add(node);

                        success++;
                    }
                    catch (Exception e)
                    {
                        DefaultLogger.Log.LogError(
                            "TestForm: Message fetching failed: " + e.Message + "\r\n" +
                            "Stack trace:\r\n" +
                            e.StackTrace);
                        fail++;
                    }

                    progressBar.Value = (int)(((double)(count - i) / count) * 100);
                }

                MessageBox.Show(this, "Mail received!\nSuccesses: " + success + "\nFailed: " + fail, "Message fetching done");

                if (fail > 0)
                {
                    MessageBox.Show(this,
                                    "Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
                                    "please consider sending your log file to the developer for fixing.\r\n" +
                                    "If you are able to include any extra information, please do so.",
                                    "Help improve OpenPop!");
                }
            }
            catch (InvalidLoginException)
            {
                MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
            }
            catch (PopServerNotFoundException)
            {
                MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
            }
            catch (PopServerLockedException)
            {
                MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
            }
            catch (LoginDelayException)
            {
                MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error occurred retrieving mail. " + e.Message, "POP3 Retrieval");
            }
            finally
            {
                // Enable the buttons again
                connectAndRetrieveButton.Enabled = true;
                uidlButton.Enabled = true;
                progressBar.Value = 100;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings frmSettings = new Settings();
            frmSettings.ShowDialog();
        }

		
    }
}
