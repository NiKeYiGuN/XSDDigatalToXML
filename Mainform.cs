using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSDDiagram.Rendering;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Net;
using System.Security.Principal;
using XSDDiagram;
using DevExpress.XtraTab;
using System.Collections;

namespace XSDDigitalToXML
{
    public partial class Mainform : DevExpress.XtraEditors.XtraForm
    {
        private DiagramPrinter _diagramPrinter;
        private MRUManager mruManager;
        private Diagram diagram = new Diagram();
        private string originalTitle = "";
        private Schema schema = new Schema();
        private bool webBrowserSupported = true;
        private Dictionary<string, XtraTabPage> hashtableTabPageByFilename = new Dictionary<string, XtraTabPage>();

        //private TextBox textBoxAnnotation = null;
        private WebBrowser webBrowserDocumentation=null;

        public Mainform()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xsd files (*.xsd)|*.xsd|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                LoadSchema(openFileDialog.FileName);
            }
        }

        private void LoadSchema(string schemaFilename)
        {
            Cursor = Cursors.WaitCursor;

            this.mruManager.AddRecentFile(schemaFilename);

            CleanupUserInterface(false);

            UpdateTitle(schemaFilename);

            schema.LoadSchema(schemaFilename);

            UpdateActionsState();

            foreach (XSDObject xsdObject in schema.Elements)
            {
                this.listViewElements.Items.Add(new ListViewItem(new string[] { xsdObject.Name, xsdObject.Type, xsdObject.NameSpace })).Tag = xsdObject;
                //this.toolStripComboBoxSchemaElement.Items.Add(xsdObject);
            }

            Cursor = Cursors.Default;

            if (this.schema.LoadError.Count > 0)
            {
                ErrorReportForm errorReportForm = new ErrorReportForm();
                errorReportForm.Errors = this.schema.LoadError;
                errorReportForm.ShowDialog(this);
            }

            this.diagram.ElementsByName = this.schema.ElementsByName;
            //if (this.schema.FirstElement != null)
            //    this.toolStripComboBoxSchemaElement.SelectedItem = this.schema.FirstElement;
            //else
            //    this.toolStripComboBoxSchemaElement.SelectedIndex = 0;

            tabControlView_Selected(null, null);

            this.tabControlView.SuspendLayout();
            foreach (string filename in this.schema.XsdFilenames)
            {
                string fullPath = filename;
                Control browser = null;
                if (webBrowserSupported)
                    browser = new WebBrowser();
                else
                    browser = new System.Windows.Forms.TextBox() { Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Both };
                browser.Dock = DockStyle.Fill;
                browser.TabIndex = 0;
                try
                {
                    new Uri(filename);
                }
                catch
                {
                    fullPath = Path.GetFullPath(filename);
                }
                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = Path.GetFileNameWithoutExtension(filename);
                tabPage.Tag = fullPath;
                //tabPage.ToolTipText = fullPath;
                tabPage.Controls.Add(browser);
                //tabPage.UseVisualStyleBackColor = true;

                this.tabControlView.TabPages.Add(tabPage);
                this.hashtableTabPageByFilename[filename] = tabPage;

            }
            this.tabControlView.ResumeLayout();

            //currentLoadedSchemaFilename = schemaFilename;
        }


        private void CleanupUserInterface(bool fullCleanup)
        {
            this.diagram.Clear();
            this.panelDiagram.VirtualSize = new Size(0, 0);
            this.panelDiagram.VirtualPoint = new Point(0, 0);
            this.panelDiagram.Clear();
            this.hashtableTabPageByFilename.Clear();
            this.listViewElements.Items.Clear();
            this.listViewAttributes.Items.Clear();
            //this.toolStripComboBoxSchemaElement.SelectedItem = "";
            //this.toolStripComboBoxSchemaElement.Items.Clear();
            //this.toolStripComboBoxSchemaElement.Items.Add("");
            this.propertyGridSchemaObject.SelectedObject = null;
            //this.textBoxElementPath.Text = "";

            while (this.tabControlView.TabPages.Count > 1)
            {
                this.tabControlView.TabPages.RemoveAt(1);
            }

            ShowDocumentation(null);

            if (fullCleanup)
            {
                UpdateTitle("");
                schema.Cleanup();
                UpdateActionsState();
            }
        }

        private void UpdateTitle(string filename)
        {
            if (filename.Length > 0)
                Text = this.originalTitle + " - " + filename;
            else
                Text = this.originalTitle;
        }

        private void UpdateActionsState()
        {
            bool isSchemaLoaded = schema.IsLoaded();
            //toolStripButtonSaveDiagram.Enabled = isSchemaLoaded;
            //toolStripButtonPrint.Enabled = isSchemaLoaded;
            //toolStripButtonAddToDiagram.Enabled = isSchemaLoaded;
            //toolStripButtonAddAllToDiagram.Enabled = isSchemaLoaded;
            //toolStripButtonRemoveAllFromDiagram.Enabled = isSchemaLoaded;
            //toolStripButtonExpandOneLevel.Enabled = isSchemaLoaded;
            //closeToolStripMenuItem.Enabled = isSchemaLoaded;
            //saveDiagramToolStripMenuItem.Enabled = isSchemaLoaded;
            //validateXMLFileToolStripMenuItem.Enabled = isSchemaLoaded;
            //printPreviewToolStripMenuItem.Enabled = isSchemaLoaded;
            //printToolStripMenuItem.Enabled = isSchemaLoaded;
        }

        private void ShowDocumentation(XMLSchema.annotation annotation)
        {
            // if (this.textBoxAnnotation == null)
            //{
                // 
                // webBrowserDocumentation
                // 
            if (webBrowserSupported)
            {
                this.webBrowserDocumentation = new System.Windows.Forms.WebBrowser();
                this.webBrowserDocumentation.Dock = System.Windows.Forms.DockStyle.Fill;
                this.webBrowserDocumentation.Location = new System.Drawing.Point(0, 0);
                this.webBrowserDocumentation.MinimumSize = new System.Drawing.Size(20, 20);
                this.webBrowserDocumentation.Name = "webBrowserDocumentation";
                this.webBrowserDocumentation.Size = new System.Drawing.Size(214, 117);
                this.webBrowserDocumentation.TabIndex = 1;
                //this.splitContainerDiagramElement.Panel2.Controls.Add(this.webBrowserDocumentation);
            }
            else
            {
                this.webBrowserDocumentation = null;
            }

                // 
                // textBoxAnnotation
                // 
                //this.textBoxAnnotation = new System.Windows.Forms.TextBox();
                //this.textBoxAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
                //this.textBoxAnnotation.Location = new System.Drawing.Point(0, 0);
                //this.textBoxAnnotation.Multiline = true;
                //this.textBoxAnnotation.Name = "textBoxAnnotation";
                //this.textBoxAnnotation.ReadOnly = true;
                //this.textBoxAnnotation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                //this.textBoxAnnotation.Size = new System.Drawing.Size(214, 117);
                //this.textBoxAnnotation.TabIndex = 0;
                //this.splitContainerDiagramElement.Panel2.Controls.Add(this.textBoxAnnotation);
            //}
            if (annotation == null)
            {
                //this.textBoxAnnotation.Text = "";
                //this.textBoxAnnotation.Visible = true;
                if (this.webBrowserDocumentation != null)
                    this.webBrowserDocumentation.Visible = false;

                return;
            }

            bool isWebDocumentation = false;
            Uri uriResult;
            foreach (object o in annotation.Items)
            {
                if (o is XMLSchema.documentation)
                {
                    XMLSchema.documentation documentation = o as XMLSchema.documentation;
                    if (documentation.Any != null && documentation.Any.Length > 0 && documentation.Any[0].Value != null)
                    {
                    }
                    else if (documentation.source != null && Uri.TryCreate(documentation.source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    {
                        if (this.webBrowserDocumentation != null)
                        {
                            isWebDocumentation = true;
                            //this.textBoxAnnotation.Visible = false;
                            this.webBrowserDocumentation.Visible = true;
                            this.webBrowserDocumentation.Navigate(documentation.source);
                        }
                    }
                    break;
                }
            }

            if (!isWebDocumentation)
            {
                //this.textBoxAnnotation.Text = DiagramHelpers.GetAnnotationText(annotation);
                //this.textBoxAnnotation.Visible = true;
                if (this.webBrowserDocumentation != null)
                    this.webBrowserDocumentation.Visible = false;
            }
        }

        private void XMLTOXSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    //https://msdn.microsoft.com/en-us/library/system.xml.schema.xmlschemainference.aspx
                    XmlReader reader = XmlReader.Create(openFileDialog.FileName);
                    XmlSchemaSet schemaSet = new XmlSchemaSet();
                    XmlSchemaInference schema = new XmlSchemaInference();

                    schemaSet = schema.InferSchema(reader);


                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "xsd files (*.xsd) | *.xsd | All files(*.*) | *.* ";
                    saveFileDialog.FilterIndex = 0;
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputFilename = saveFileDialog.FileName;
                        using (TextWriter textWriter = File.CreateText(outputFilename))
                        {
                            foreach (XmlSchema xmlSchema in schemaSet.Schemas())
                            {
                                xmlSchema.Write(textWriter);
                            }
                        }

                        if (MessageBox.Show(this, "Would you open the newly inferred XSD file?", "Open XSD file", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            LoadSchema(outputFilename);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cursor = Cursors.Default;
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SVG files (*.svg)|*.svg" + (Options.IsRunningOnMono ? "" : "|EMF files (*.emf)|*.emf") + "|PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg|TXT files (*.txt)|*.txt|CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilename = saveFileDialog.FileName;
                try
                {
                    DiagramExporter exporter = new DiagramExporter(diagram);
                    Graphics g1 = this.panelDiagram.DiagramControl.CreateGraphics();
                    exporter.Export(outputFilename, g1, new DiagramAlertHandler(SaveAlert), new Dictionary<string, object>()
                            {
                                { "TextOutputFields", Options.TextOutputFields }
                                //For future parameters, {}
                            });
                    g1.Dispose();
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show("已经超过系统限制.\r\n请移除部分文件！");
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
                catch (System.Runtime.InteropServices.ExternalException ex)
                {
                    MessageBox.Show("已经超过系统限制.\r\n请移除部分元素!.");
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
            }
        }

        bool SaveAlert(string title, string message)
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        static List<string> validationErrorMessages = new List<string>();

        public static void ValidationHandler(object sender, ValidationEventArgs e)
        {
            //if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
            validationErrorMessages.Add(string.Format("{4}: [{3}] Line: {0}, Position: {1} \"{2}\"",
                e.Exception.LineNumber, e.Exception.LinePosition, e.Exception.Message, validationErrorMessages.Count, e.Severity));
        }

        private void VilateMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    validationErrorMessages.Clear();

                    StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                    string xmlSource = streamReader.ReadToEnd();
                    streamReader.Close();

                    //XmlDocument x = new XmlDocument();
                    //x.LoadXml(xmlSource);

                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.CloseInput = true;
                    settings.ValidationType = ValidationType.Schema;
                    settings.ProhibitDtd = false;
                    settings.XmlResolver = null;
                    settings.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
                    settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings |
                                                XmlSchemaValidationFlags.ProcessIdentityConstraints |
                                                XmlSchemaValidationFlags.ProcessInlineSchema |
                                                XmlSchemaValidationFlags.ProcessSchemaLocation
                                                ; //| XmlSchemaValidationFlags.AllowXmlAttributes;
                    //settings.Schemas.Add("http://www.collada.org/2005/11/COLLADASchema", currentLoadedSchemaFilename);
                    //settings.Schemas.Add(null, currentLoadedSchemaFilename); // = sc;
                    List<string> schemas = new List<string>(schema.XsdFilenames);
                    schemas.Reverse();
                    foreach (string schemaFilename in schemas)
                    {
                        try
                        {
                            settings.Schemas.Add(null, schemaFilename);
                        }
                        catch (Exception ex)
                        {
                            validationErrorMessages.Add(string.Format("Error while parsing {0}, Message: {1}",
                                schemaFilename, ex.Message));
                        }
                    }

                    StringReader r = new StringReader(xmlSource);
                    using (XmlReader validatingReader = XmlReader.Create(r, settings))
                    {
                        while (validatingReader.Read()) { /* just loop through document */ }
                    }

                    Cursor = Cursors.Default;

                    ErrorReportForm errorReportForm = new ErrorReportForm();
                    errorReportForm.Errors = validationErrorMessages;
                    errorReportForm.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;

                    validationErrorMessages.Add(string.Format("Error while validating {0}, Message: {1}",
                        openFileDialog.FileName, ex.Message));
                    //MessageBox.Show("Cannot validate: " + ex.Message);
                    ErrorReportForm errorReportForm = new ErrorReportForm();
                    errorReportForm.Errors = validationErrorMessages;
                    errorReportForm.ShowDialog(this);
                }
                Cursor = Cursors.Default;

                if (validationErrorMessages.Count == 0)
                    MessageBox.Show("No issue found");
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_diagramPrinter == null)
                {
                    _diagramPrinter = new DiagramPrinter();
                }
                _diagramPrinter.Diagram = diagram;

                _diagramPrinter.Print(true, Options.IsRunningOnMono);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BeHindToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = this.tabControlView.SelectedTabPageIndex;
            --index;
            if (index < 0) index = this.tabControlView.TabPages.Count - 1;
            this.tabControlView.SelectedTabPageIndex = index;
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.tabControlView.SelectedTabPageIndex;
            ++index;
            this.tabControlView.SelectedTabPageIndex = index % this.tabControlView.TabPages.Count;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        private void tabControlView_Click(object sender, EventArgs e)
        {
            if (tabControlView.SelectedTabPage.Tag != null)
            {
                Control webBrowser = tabControlView.SelectedTabPage.Controls[0] as Control;
                if (webBrowser != null)
                {
                    webBrowser.Select();
                }                 
            }
        }

        private void tabControlView_Enter(object sender, EventArgs e)
        {
            if (tabControlView.SelectedTabPage != null && tabControlView.SelectedTabPage.Tag != null)
            {
                Control webBrowser = tabControlView.SelectedTabPage.Controls[0] as Control;
                if (webBrowser != null)
                    webBrowser.Focus();
            }
            else
            {
                this.panelDiagram.Focus();
            }                
        }

        private void tabControlView_Selected(object sender, TabPageEventArgs e)
        {
            if (tabControlView.SelectedTabPage.Tag != null)
            {
                WebBrowser webBrowser = tabControlView.SelectedTabPage.Controls[0] as WebBrowser;
                if (webBrowser != null)
                {
                    string url = tabControlView.SelectedTabPage.Tag as string;
                    //if (webBrowser.Url == null || webBrowser.Url != new Uri(url))
                    if (webBrowser.Document == null)
                        webBrowser.Navigate(url);
                    webBrowser.Select();
                }
                else
                {
                    TextBox textBrowser = tabControlView.SelectedTabPage.Controls[0] as TextBox;
                    if (textBrowser != null)
                    {
                        string url = tabControlView.SelectedTabPage.Tag as string;
                        if (string.IsNullOrEmpty(textBrowser.Text))
                        {
                            try
                            {
                                //HttpWebRequest webRequestObject = (HttpWebRequest)WebRequest.Create(url);
                                ////WebRequestObject.UserAgent = ".NET Framework/2.0";
                                ////WebRequestObject.Referer = "http://www.example.com/";
                                //WebResponse response = webRequestObject.GetResponse();
                                //Stream webStream = response.GetResponseStream();
                                //StreamReader reader = new StreamReader(webStream);
                                //textBrowser.Text = reader.ReadToEnd();
                                //reader.Close();
                                //webStream.Close();
                                //response.Close();

                                WebClient client = new WebClient();
                                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                                Stream data = client.OpenRead(url);
                                StreamReader reader = new StreamReader(data);
                                textBrowser.Text = reader.ReadToEnd().Replace("\r\n", "\n").Replace("\n", "\r\n");
                                data.Close();
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                textBrowser.Text = ex.Message;
                            }
                        }
                        textBrowser.Select();
                    }
                }
            }
        }

        private void panelDiagram_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem lvi = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
                if (lvi != null)
                {
                    listViewElements_DoubleClick(sender, e);
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                Mainform_DragDrop(sender, e);
        }

        private void Mainform_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator"))
            {
                string url = e.Data.GetData(DataFormats.Text, true) as string;
                if (!string.IsNullOrEmpty(url))
                    LoadSchema(url.Trim());
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                    LoadSchema(files[0]);
            }
        }

        private void Mainform_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent("UniformResourceLocator"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Mainform_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Control && (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0))
            //{
            //    this.toolStripComboBoxZoom.SelectedIndex = 8;
            //}
            //else if (e.Control && (e.KeyCode == Keys.F))
            //{
            //    this.toolStripTextBoxSearch.SelectAll();
            //    this.toolStripTextBoxSearch.Focus();
            //}
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            this.mruManager = new MRUManager("xsddiagram");


            //this.toolStripComboBoxZoom.SelectedIndex = 8;
            //this.toolStripComboBoxAlignement.SelectedIndex = 1;

            if (!string.IsNullOrEmpty(Options.InputFile))
            {
                LoadSchema(Options.InputFile);
                foreach (var rootElement in Options.RootElements)
                {
                    string elementName = rootElement;
                    string elementNamespace = null;
                    if (!string.IsNullOrEmpty(elementName))
                    {
                        var pos = rootElement.IndexOf("@");
                        if (pos != -1)
                        {
                            elementName = rootElement.Substring(0, pos);
                            elementNamespace = rootElement.Substring(pos + 1);
                        }
                    }

                    foreach (var element in schema.Elements)
                    {
                        if ((elementNamespace != null && elementNamespace == element.NameSpace && element.Name == elementName) ||
                            (elementNamespace == null && element.Name == elementName))
                        {
                            diagram.Add(element.Tag, element.NameSpace);
                        }
                    }
                }
                for (int i = 0; i < Options.ExpandLevel; i++)
                {
                    diagram.ExpandOneLevel();
                }
                UpdateDiagram();
            }
        }

        private void UpdateDiagram()
        {
            if (this.diagram.RootElements.Count != 0)
            {
                Graphics g = this.panelDiagram.DiagramControl.CreateGraphics();
                this.diagram.Layout(g);
                g.Dispose();
                Size bbSize = this.diagram.BoundingBox.Size + this.diagram.Padding + this.diagram.Padding;
                this.panelDiagram.VirtualSize = new Size((int)(bbSize.Width * this.diagram.Scale), (int)(bbSize.Height * this.diagram.Scale));
            }
            else
                this.panelDiagram.VirtualSize = new Size(0, 0);
        }

        private void listViewElements_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;
        }

        private void listViewElements_Click(object sender, EventArgs e)
        {
            if (this.listViewElements.SelectedItems.Count > 0)
                SelectSchemaElement(this.listViewElements.SelectedItems[0].Tag as XSDObject);
        }

        private void SelectSchemaElement(XSDObject xsdObject)
        {
            SelectSchemaElement(xsdObject.Tag, xsdObject.NameSpace);
        }
        private void SelectSchemaElement(DiagramItem diagramBase)
        {
            SelectSchemaElement(diagramBase.TabSchema, diagramBase.NameSpace);
        }
        private void SelectSchemaElement(XMLSchema.openAttrs openAttrs, string nameSpace)
        {
            this.propertyGridSchemaObject.SelectedObject = openAttrs;
            ShowDocumentation(null);

            XMLSchema.annotated annotated = openAttrs as XMLSchema.annotated;
            if (annotated != null)
            {
               
                if (annotated.annotation != null)
                    ShowDocumentation(annotated.annotation);

                ShowEnumerate(annotated);

                List<XSDAttribute> listAttributes = DiagramHelpers.GetAnnotatedAttributes(this.schema, annotated, nameSpace);
                this.listViewAttributes.Items.Clear();
                listAttributes.Reverse();
                foreach (XSDAttribute attribute in listAttributes)
                {
                    string s = "";
                    if (attribute.Tag != null && attribute.Tag.simpleType != null && attribute.Tag.simpleType.Item is XMLSchema.restriction)
                    {
                        XMLSchema.restriction r = attribute.Tag.simpleType.Item as XMLSchema.restriction;
                        if (r.Items != null)
                        {
                            for (int i = 0; i < r.Items.Length; i++)
                            {
                                s += r.ItemsElementName[i].ToString() + "(" + r.Items[i].id + " " + r.Items[i].value + ");";
                            }
                        }
                    }

                    this.listViewAttributes.Items.Add(new ListViewItem(new string[] { attribute.Name, attribute.Type, attribute.Use, attribute.DefaultValue, s })).Tag = attribute;
                }
                //Adrian--
            }
        }

        private void ShowEnumerate(XMLSchema.annotated annotated)
        {
            //this.listViewEnumerate.Items.Clear();

            if (annotated != null)
            {
                XMLSchema.element element = annotated as XMLSchema.element;
                if (element != null && element.type != null)
                {
                    XSDObject xsdObject;
                    if (this.schema.ElementsByName.TryGetValue(DiagramHelpers.QualifiedNameToFullName("type", element.type), out xsdObject) && xsdObject != null)
                    {
                        XMLSchema.annotated annotatedElement = xsdObject.Tag as XMLSchema.annotated;
                        if (annotatedElement is XMLSchema.simpleType)
                            ShowEnumerate(annotatedElement as XMLSchema.simpleType);
                    }
                }
            }
        }

        private void listViewElements_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewElements.ListViewItemSorter = new ListViewItemComparer(e.Column, this.listViewElements);
        }

        class ListViewItemComparer : IComparer
        {
            private int column;
            private ListView listView;
            public ListViewItemComparer(int column, ListView listView)
            {
                this.column = column;
                this.listView = listView;

                switch (this.listView.Sorting)
                {
                    case SortOrder.None: this.listView.Sorting = SortOrder.Ascending; break;
                    case SortOrder.Ascending: this.listView.Sorting = SortOrder.Descending; break;
                    case SortOrder.Descending: this.listView.Sorting = SortOrder.Ascending; break;
                }
            }
            public int Compare(object x, object y)
            {
                int result = 0;
                if (this.listView.Sorting == SortOrder.Ascending)
                    result = String.Compare(((ListViewItem)x).SubItems[this.column].Text, ((ListViewItem)y).SubItems[column].Text);
                if (this.listView.Sorting == SortOrder.Descending)
                    result = -String.Compare(((ListViewItem)x).SubItems[this.column].Text, ((ListViewItem)y).SubItems[column].Text);

                return result;
            }
        }

        private void listViewElements_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewElements.SelectedItems.Count > 0)
            {
                DiagramItem firstDiagramItem = null;

                foreach (ListViewItem lvi in this.listViewElements.SelectedItems)
                {
                    XSDObject xsdObject = lvi.Tag as XSDObject;
                    DiagramItem diagramItem = this.diagram.Add(xsdObject.Tag as XMLSchema.openAttrs, xsdObject.NameSpace);
                    if (firstDiagramItem == null && diagramItem != null)
                    {
                        firstDiagramItem = diagramItem;
                    }
                }
                if (firstDiagramItem != null)
                    SelectDiagramElement(firstDiagramItem, true);
                else
                    UpdateDiagram();
            }
        }

        private void SelectDiagramElement(DiagramItem element, bool scrollToElement)
        {
            //this.textBoxElementPath.Text = "";

            if (element == null)
            {
                //this.toolStripComboBoxSchemaElement.SelectedItem = "";
                this.propertyGridSchemaObject.SelectedObject = null;
                this.listViewAttributes.Items.Clear();
            }
            else
            {
                XSDObject xsdObject;
                //if (this.schema.ElementsByName.TryGetValue(element.FullName, out xsdObject) && xsdObject != null)
                //    this.toolStripComboBoxSchemaElement.SelectedItem = xsdObject;
                //else
                //    this.toolStripComboBoxSchemaElement.SelectedItem = null;

                SelectSchemaElement(element);

                string path = '/' + element.Name;
                DiagramItem parentElement = element.Parent;
                while (parentElement != null)
                {
                    if (parentElement.ItemType == DiagramItemType.element && !string.IsNullOrEmpty(parentElement.Name))
                        path = '/' + parentElement.Name + path;
                    parentElement = parentElement.Parent;
                }
                //this.textBoxElementPath.Text = path;
            }

            this.diagram.SelectElement(element);
            UpdateDiagram();
            if (scrollToElement)
                this.panelDiagram.ScrollTo(this.diagram.ScalePoint(element.Location), true);
        }

        private void listViewElements_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listViewElements.DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        private void listViewAttributes_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;
        }

        private void listViewAttributes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewAttributes.ListViewItemSorter = new ListViewItemComparer(e.Column, this.listViewAttributes);
        }

        private void listViewAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewAttributes.SelectedItems.Count > 0)
            {
                XSDAttribute xsdAttribute = this.listViewAttributes.SelectedItems[0].Tag as XSDAttribute;
                XMLSchema.attribute attribute = xsdAttribute.Tag;
                if (attribute != null && attribute.annotation != null)
                    ShowDocumentation(attribute.annotation);
                else
                    ShowDocumentation(null);
                ShowEnumerate(attribute);
            }
        }
    }
}
