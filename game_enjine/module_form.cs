using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_367_form.ver1._6_pre_beta
{
    public partial class module_form : Form
    {
        public string code_;
        private static string script_text = null;
        private static string syntax_text = null;
        int cursor_position = 0;
        //HtmlElement textarea;
        public module_form()
        {
            InitializeComponent();
            string data = null;
            string str_1, str_2, str_3;
            System.IO.StreamReader file = new System.IO.StreamReader("test.html");

            while ((str_1 = file.ReadLine()) != null)
            {
                data += str_1;
            }
            System.IO.StreamReader f__reader = new StreamReader("code_syntax.prjh");

            while ((str_2 = f__reader.ReadLine()) != null)
            {
                syntax_text += str_2;
            }
            System.IO.StreamReader f_reader = new StreamReader("code_sourse.prjh");

            while ((str_3 = f_reader.ReadLine()) != null)
            {
                script_text += str_3;
            }

            webBrowser1.DocumentText = data;
            string app_dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly(
                ).GetName().CodeBase);
            webBrowser1.Url = new Uri(Path.Combine(app_dir, @"test.html"));
            var doc = webBrowser1.Document.OpenNew(true);
            doc.Write(data);
            webBrowser1.PreviewKeyDown += WebBrowser1_PreviewKeyDown;
            var item = doc.GetElementById("text_code");
        }
        bool t = false;
        private void WebBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {                
                case Keys.Tab:
                    {
                        if (t)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] { "\t" });
                        }                        
                    }
                    break;
                case Keys.Enter:
                    {
                        if (t)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] { "\n" });
                        }
                    }
                    break;
                case Keys.Space:
                    if (t)
                    {
                        webBrowser1.Document.InvokeScript("set_code", new object[] { " " });
                    }
                    break;
                case Keys.Left:
                    break;
                case Keys.Up:
                    break;
                case Keys.Right:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;

                case Keys.A: 
                case Keys.B:                   
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                    if (t)
                    {
                        var key = (System.Windows.Forms.Keys)e.KeyCode;
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                key.ToString()
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                key.ToString().ToLower()
                            });
                        }
                    }
                    break;
                case Keys.D0:
                    if (t)
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                ")"
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "0"
                            });
                        }
                    }
                    break;
                case Keys.D9:
                    if (t)
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "("
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "9"
                            });
                        }
                    }
                    break;
                case Keys.OemSemicolon:
                    if (t)
                    {
                        webBrowser1.Document.InvokeScript("set_code", new object[] {
                                ";"
                            });
                    }
                    break;
                case Keys.Oemcomma:
                    if (t)
                    {
                        webBrowser1.Document.InvokeScript("set_code", new object[] {
                                ","
                            });
                    }
                    break;
                case Keys.OemPeriod:
                    if (t)
                    {
                        webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "."
                            });
                    }
                    break;
                case Keys.OemQuestion:
                    if (t)
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "?"
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "/"
                            });
                        }
                    }
                    break;
                case Keys.Oemplus:
                    if (t)
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "+"
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "="
                            });
                        }
                    }
                    break;
                case Keys.OemCloseBrackets:
                    if (t)
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "}"
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "]"
                            });
                        }
                    }
                    break;
                case Keys.OemOpenBrackets:
                    if (t)
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "{"
                            });
                        }
                        else
                        {
                            webBrowser1.Document.InvokeScript("set_code", new object[] {
                                "["
                            });
                        }                        
                    }
                    break;               

                case Keys.NumPad0:
                    break;
                case Keys.NumPad1:
                    break;
                case Keys.NumPad2:
                    break;
                case Keys.NumPad3:
                    break;
                case Keys.NumPad4:
                    break;
                case Keys.NumPad5:
                    break;
                case Keys.NumPad6:
                    break;
                case Keys.NumPad7:
                    break;
                case Keys.NumPad8:
                    break;
                case Keys.NumPad9:
                    break;

                default:
                    break;
            }
            t = !t;            
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            //WebBrowser web_browser = (WebBrowser)sender;
            HtmlDocument docum = webBrowser1.Document;
            HtmlElement body = docum.GetElementsByTagName("body")[0];

//            textarea = webBrowser1.Document.GetElementsByTagName();


//            textarea.KeyDown += textarea_KeyDown;
            HtmlElement script = docum.CreateElement("script");
            HtmlElement script_1 = docum.CreateElement("script");
            script_1.SetAttribute("text", syntax_text);
            script.SetAttribute("text", script_text);
            body.AppendChild(script_1);
            body.AppendChild(script);
            //richTextBox1.Text = body.InnerHtml;
            //webBrowser1.Document.InvokeScript("Syntax");
            webBrowser1.Document.InvokeScript("set_code");
        }

        private void textarea_KeyDown(object sender, HtmlElementEventArgs e)
        {
            
        }
    }
}
