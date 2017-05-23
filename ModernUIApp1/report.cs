using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;
using Novacode;

namespace Dictionary
{
    class report
    {
        private string html;
        private string html2;
        private string html3;
        private string html4;
       

        public report()
        {
        }
    
        public void html_report()
        {
            try
            {
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
                string src = string.Format("{0}css\\", AppDomain.CurrentDomain.BaseDirectory);
                string path = string.Format("{0}Reports\\html\\css\\", dir);
                DirectoryCopy(src, path, true);
                string src2 = string.Format("{0}js\\", AppDomain.CurrentDomain.BaseDirectory);
                string path2 = string.Format("{0}Reports\\html\\js\\", dir);
                DirectoryCopy(src2, path2, true);
                string src3 = string.Format("{0}Images\\",dir);
                string path3 = string.Format("{0}Reports\\html\\img\\", dir);
                DirectoryCopy(src3, path3, true);
                html_header();
                html_body();
                html_footer();
                html_write();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void html2_report()
        {
            try{
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
            string src = string.Format("{0}css\\", AppDomain.CurrentDomain.BaseDirectory);
            string path = string.Format("{0}Reports\\html\\css\\", dir);
            DirectoryCopy(src, path, true);
            string src2 = string.Format("{0}js\\", AppDomain.CurrentDomain.BaseDirectory);
            string path2 = string.Format("{0}Reports\\html\\js\\", dir);
            DirectoryCopy(src2, path2, true);
            string src3 = string.Format("{0}Images\\", dir);
            string path3 = string.Format("{0}Reports\\html\\img\\", dir);
            DirectoryCopy(src3, path3, true);
            html2_header();
            html2_body();
            html2_footer();
            html2_write();
             }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void html3_report()
        {
            try{
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
            string src = string.Format("{0}css\\", AppDomain.CurrentDomain.BaseDirectory);
            string path = string.Format("{0}Reports\\html\\css\\",dir);
            DirectoryCopy(src, path, true);
            string src2 = string.Format("{0}js\\", AppDomain.CurrentDomain.BaseDirectory);
            string path2 = string.Format("{0}Reports\\html\\js\\", dir);
            DirectoryCopy(src2, path2, true);
            string src3 = string.Format("{0}Images\\", dir);
            string path3 = string.Format("{0}Reports\\html\\img\\", dir);
            DirectoryCopy(src3, path3, true);
            html3_header();
            html3_body();
            html3_footer();
            html3_write();
             }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void html4_report()
        {
            try{
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
            string src = string.Format("{0}css\\", AppDomain.CurrentDomain.BaseDirectory);
            string path = string.Format("{0}Reports\\html\\css\\", dir);
            DirectoryCopy(src, path, true);
            string src2 = string.Format("{0}js\\", AppDomain.CurrentDomain.BaseDirectory);
            string path2 = string.Format("{0}Reports\\html\\js\\", dir);
            DirectoryCopy(src2, path2, true);
            string src3 = string.Format("{0}Images\\",dir);
            string path3 = string.Format("{0}Reports\\html\\img\\", dir);
            DirectoryCopy(src3, path3, true);
            html4_header();
            html4_body();
            html4_footer();
            html4_write();
             }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
               private void html_header()
               {
                   username u = new username();
                   string name;
                   u.reader(out name);
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine(String.Format("<!DOCTYPE html>\n<html lang=\"en\">\n"));
                   sb.AppendLine(String.Format("<head>\n<title>Report for {0}</title>\n<meta charset=\"utf-8\">\n<link rel=\"icon\" href=\"img/icon.ico\" type=\"image/x-icon\">\n<link rel=\"shortcut icon\" href=\"img/icon.ico\" type=\"image/x-icon\" />",name));
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string img = string.Format("{0}Images", dir);
                   string path = string.Format("{0}Reports\\html\\img", dir);
                   if (!Directory.Exists(path))
                   {
                       Directory.CreateDirectory(path);
                   }
                   var fileName = "icon.ico";
                   var source = Path.Combine(img, fileName);
                   var destination = Path.Combine(path, fileName);
                   File.Copy(source, destination,true);
                  string description = "This page has been created for "+ name+ " to see report of success in the tests.";
                   string keywords = "report,test,dictionary,success,course work, semester project";
                    sb.AppendLine(String.Format("<meta name=\"description\" content=\"{0}\">\n<meta name=\"keywords\" content=\"{1}\">\n<meta name=\"author\" content=\"Berk Arslan\">",description,keywords));
                    sb.AppendLine(String.Format("<link rel=\"stylesheet\" href=\"css/bootstrap.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/responsive.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/style.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/touchTouch.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/kwicks-slider.css\" type=\"text/css\" media=\"screen\">\n<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300' rel='stylesheet' type='text/css'>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/superfish.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.flexslider-min.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.kwicks-1.5.1.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.easing.1.3.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/touchTouch.jquery.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/preload.js\"></script>"));
                    sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jvs.js\"></script>"));
                    sb.AppendLine("</head>");

                    html+= sb.ToString();
                    
                   
               }
               private void html2_header()
               {
                   username u = new username();
                   string name;
                   u.reader(out name);
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine(String.Format("<!DOCTYPE html>\n<html lang=\"en\">\n"));
                   sb.AppendLine(String.Format("<head>\n<title>Report for {0}</title>\n<meta charset=\"utf-8\">\n<link rel=\"icon\" href=\"img/icon.ico\" type=\"image/x-icon\">\n<link rel=\"shortcut icon\" href=\"img/icon.ico\" type=\"image/x-icon\" />", name));
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string img = string.Format("{0}Images", dir);
                   string path = string.Format("{0}Reports\\html\\img", dir);
                   if (!Directory.Exists(path))
                   {
                       Directory.CreateDirectory(path);
                   }
                   var fileName = "icon.ico";
                   var source = Path.Combine(img, fileName);
                   var destination = Path.Combine(path, fileName);
                   File.Copy(source, destination, true);
                   string description = "This page has been created for " + name + " to see report of success in the tests.";
                   string keywords = "report,test,dictionary,success,course work, semester project";
                   sb.AppendLine(String.Format("<meta name=\"description\" content=\"{0}\">\n<meta name=\"keywords\" content=\"{1}\">\n<meta name=\"author\" content=\"Berk Arslan\">", description, keywords));
                   sb.AppendLine(String.Format("<link rel=\"stylesheet\" href=\"css/bootstrap.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/responsive.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/style.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/touchTouch.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/kwicks-slider.css\" type=\"text/css\" media=\"screen\">\n<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300' rel='stylesheet' type='text/css'>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/superfish.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.flexslider-min.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.kwicks-1.5.1.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.easing.1.3.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/touchTouch.jquery.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/preload.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jvs.js\"></script>"));
                   sb.AppendLine("</head>");

                   html2 += sb.ToString();


               }
               private void html3_header()
               {
                   username u = new username();
                   string name;
                   u.reader(out name);
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine(String.Format("<!DOCTYPE html>\n<html lang=\"en\">\n"));
                   sb.AppendLine(String.Format("<head>\n<title>Report for {0}</title>\n<meta charset=\"utf-8\">\n<link rel=\"icon\" href=\"img/icon.ico\" type=\"image/x-icon\">\n<link rel=\"shortcut icon\" href=\"img/icon.ico\" type=\"image/x-icon\" />", name));
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string img = string.Format("{0}Images", dir);
                   string path = string.Format("{0}Reports\\html\\img", dir);
                   if (!Directory.Exists(path))
                   {
                       Directory.CreateDirectory(path);
                   }
                   var fileName = "icon.ico";
                   var source = Path.Combine(img, fileName);
                   var destination = Path.Combine(path, fileName);
                   File.Copy(source, destination, true);
                   string description = "This page has been created for " + name + " to see report of success in the tests.";
                   string keywords = "report,test,dictionary,success,course work, semester project";
                   sb.AppendLine(String.Format("<meta name=\"description\" content=\"{0}\">\n<meta name=\"keywords\" content=\"{1}\">\n<meta name=\"author\" content=\"Berk Arslan\">", description, keywords));
                   sb.AppendLine(String.Format("<link rel=\"stylesheet\" href=\"css/bootstrap.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/responsive.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/style.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/touchTouch.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/kwicks-slider.css\" type=\"text/css\" media=\"screen\">\n<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300' rel='stylesheet' type='text/css'>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/superfish.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.flexslider-min.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.kwicks-1.5.1.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.easing.1.3.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/touchTouch.jquery.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/preload.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jvs.js\"></script>"));
                   sb.AppendLine("</head>");

                   html3 += sb.ToString();


               }
               private void html4_header()
               {
                   username u = new username();
                   string name;
                   u.reader(out name);
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine(String.Format("<!DOCTYPE html>\n<html lang=\"en\">\n"));
                   sb.AppendLine(String.Format("<head>\n<title>Report for {0}</title>\n<meta charset=\"utf-8\">\n<link rel=\"icon\" href=\"img/icon.ico\" type=\"image/x-icon\">\n<link rel=\"shortcut icon\" href=\"img/icon.ico\" type=\"image/x-icon\" />", name));
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string img = string.Format("{0}Images", dir);
                   string path = string.Format("{0}Reports\\html\\img", dir);
                   if (!Directory.Exists(path))
                   {
                       Directory.CreateDirectory(path);
                   }
                   var fileName = "icon.ico";
                   var source = Path.Combine(img, fileName);
                   var destination = Path.Combine(path, fileName);
                   File.Copy(source, destination, true);
                   string description = "This page has been created for " + name + " to see report of success in the tests.";
                   string keywords = "report,test,dictionary,success,course work, semester project";
                   sb.AppendLine(String.Format("<meta name=\"description\" content=\"{0}\">\n<meta name=\"keywords\" content=\"{1}\">\n<meta name=\"author\" content=\"Berk Arslan\">", description, keywords));
                   sb.AppendLine(String.Format("<link rel=\"stylesheet\" href=\"css/bootstrap.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/responsive.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/style.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/touchTouch.css\" type=\"text/css\" media=\"screen\">\n<link rel=\"stylesheet\" href=\"css/kwicks-slider.css\" type=\"text/css\" media=\"screen\">\n<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300' rel='stylesheet' type='text/css'>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/superfish.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.flexslider-min.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.kwicks-1.5.1.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jquery.easing.1.3.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/touchTouch.jquery.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/preload.js\"></script>"));
                   sb.AppendLine(String.Format("<script type=\"text/javascript\" src=\"js/jvs.js\"></script>"));
                   sb.AppendLine("</head>");

                   html4 += sb.ToString();


               }
               private void html_body()
               {
                 
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<body>");
                   sb.AppendLine("<div class=\"spinner\"></div>");
                   sb.AppendLine("<header>");
                   sb.AppendLine("<div class=\"container clearfix\">");
                   sb.AppendLine("<div class=\"row\">");
                   sb.AppendLine("<div class=\"span12\">");
                   sb.AppendLine("<div class=\"navbar navbar_\">");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine("<img  src=\"img/logor.png\" width=\"220 px\" height=\"150 px\" alt=\"Berk Arslan\">");
                   sb.AppendLine("<a class=\"btn btn-navbar btn-navbar_\" data-toggle=\"collapse\" data-target=\".nav-collapse_\">Menu <span class=\"icon-bar\"></span> </a>");
                   sb.AppendLine("<div class=\"nav-collapse nav-collapse_  collapse\">");
                   sb.AppendLine("<ul class=\"nav sf-menu\">");
                   sb.AppendLine(" <li class=\"active\"><a href=\"index.html\">Home</a></li>");
                   sb.AppendLine(" <li><a href=\"detail.html\">Details</a></li>");
                   sb.AppendLine(" <li><a href=\"guide.html\">Guide</a></li>");
                   sb.AppendLine(" <li><a href=\"contact.html\">Contact</a></li>");
                   sb.AppendLine("</ul></div></div></div></div></div></div></header> ");
                   sb.AppendLine("<div class=\"bg-content\">");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine(" <div class=\"row\">");
                   sb.AppendLine("<div class=\"span12\"> ");
                   sb.AppendLine(" <div class=\"flexslider\"> ");
                   sb.AppendLine("<ul class=\"slides\"> ");
                   sb.AppendLine(" <li> <img src=\"img/graph.png\" width=\"770 px\" height=\"393 px\" alt=\"\" > </li>");
                   sb.AppendLine(" <li> <img src=\"img/graph.png\" width=\"770 px\" height=\"393 px\" alt=\"\" > </li>");
                   sb.AppendLine(" <li> <img src=\"img/graph.png\" width=\"770 px\" height=\"393 px\" alt=\"\" > </li>");
                   sb.AppendLine(" <li> <img src=\"img/graph.png\" width=\"770 px\" height=\"393 px\" alt=\"\" > </li>");
                   sb.AppendLine(" <li> <img src=\"img/graph.png\" width=\"770 px\" height=\"393 px\" alt=\"\" > </li></ul></div>");
                   sb.AppendLine("<span id=\"responsiveFlag\"></span> ");
                   sb.AppendLine("<div class=\"block-slogan\"> ");
                   sb.AppendLine("<h2>Report</h2><div>");
                   sb.AppendLine("<p>This report has been created by <a target=\"_blank\" class=\"link-1\"> Dictionary</a>.");
                   sb.AppendLine("On the slider you can see the graph for all test result.</p>");
                   sb.AppendLine("</div></div></div></div></div>");
                   sb.AppendLine(" <div id=\"content\" class=\"content-extra\"><div class=\"ic\">Dictionary</div>");
                   sb.AppendLine("<div class=\"row-1\"> ");
                   sb.AppendLine("<div class=\"container\"> ");
                   sb.AppendLine("<div class=\"row\"> ");
                   sb.AppendLine(" <ul class=\"thumbnails thumbnails-1\">");
                   sb.AppendLine("  <li class=\"span3\">");
                   sb.AppendLine(" <a href=\"detail.html\" >    <div class=\"thumbnail thumbnail-1\">");
                   sb.AppendLine(" <h3>Report Details</h3>");
                   sb.AppendLine(" <img  src=\"img/thumbnail_report.png\" width=\"150 px\" height=\"150 px\" alt=\"\">");
                   sb.AppendLine(" <section><p>Date by date test analysis</p></section></div></a></li>");
                   sb.AppendLine("  <li class=\"span3\">");
                   sb.AppendLine(" <a href=\"guide.html\" >    <div class=\"thumbnail thumbnail-1\">");
                   sb.AppendLine(" <h3>User Guide</h3>");
                   sb.AppendLine(" <img  src=\"img/user_guide.png\" width=\"150 px\" height=\"150 px\" alt=\"\">");
                   sb.AppendLine(" <section><p>How to use Dictionary</p></section></div></a></li>");
                  
                   sb.AppendLine("  <li class=\"span3\">");
                   sb.AppendLine(" <a href=\"contact.html\" >    <div class=\"thumbnail thumbnail-1\">");
                   sb.AppendLine(" <h3>Contact</h3>");
                   sb.AppendLine(" <img  src=\"img/contact.png\" width=\"150 px\" height=\"150 px\" alt=\"\">");
                   sb.AppendLine(" <section><p>Feel free to contact Us</p></section></div></a></li></ul>");
                   sb.AppendLine(" </div></div></div>");
                   sb.AppendLine(" <div class=\"container\">");
                   sb.AppendLine(" <div class=\"row\">");
                   sb.AppendLine(" <article class=\"span6\">");
                   sb.AppendLine(" <h3>Shortly about me</h3>");
                   sb.AppendLine("  <div class=\"wrapper\">");
                   sb.AppendLine("  <figure class=\"img-indent\"><img src=\"img/me.jpg \" alt=\"Berk Arslan\" /></figure>");
                   sb.AppendLine("  <div class=\"inner-1 overflow extra\">");
                   sb.AppendLine("  <div class=\"txt-1\">My name is Berk Arslan.</div>");
                   sb.AppendLine("  I am from Turkey. I study in Khpi\"Kharkiv National University\".I know C# , C++ , Java , Html and Php languages.</div></div></article> ");
                   sb.AppendLine("  </div></div></div></div>");
                               
                   html += sb.ToString();      
                }
               private void html2_body()
               {

                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<body>");
                   sb.AppendLine("<div class=\"spinner\"></div>");
                   sb.AppendLine("<header>");
                   sb.AppendLine("<div class=\"container clearfix\">");
                   sb.AppendLine("<div class=\"row\">");
                   sb.AppendLine("<div class=\"span12\">");
                   sb.AppendLine("<div class=\"navbar navbar_\">");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine("<img  src=\"img/logor.png\" width=\"220 px\" height=\"150 px\" alt=\"Berk Arslan\">");
                   sb.AppendLine("<a class=\"btn btn-navbar btn-navbar_\" data-toggle=\"collapse\" data-target=\".nav-collapse_\">Menu <span class=\"icon-bar\"></span> </a>");
                   sb.AppendLine("<div class=\"nav-collapse nav-collapse_  collapse\">");
                   sb.AppendLine("<ul class=\"nav sf-menu\">");
                   sb.AppendLine(" <li><a href=\"index.html\">Home</a></li>");
                   sb.AppendLine(" <li class=\"active\"><a href=\"detail.html\">Details</a></li>");
                   sb.AppendLine(" <li><a href=\"guide.html\">Guide</a></li>");
                   sb.AppendLine(" <li><a href=\"contact.html\">Contact</a></li>");
                   sb.AppendLine("</ul></div></div></div></div></div></div></header> ");
                   sb.AppendLine("<div class=\"bg-content\">");
                   sb.AppendLine("<div id=\"content\"><div class=\"ic\">Dictionary</div>");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine(" <div class=\"row\">");
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Results\\", dir);
                   string[] files = Directory.GetFiles(path);
                   for (int i = 0; i < files.Count(); i++)
                   {
                       result r = new result();
                       XmlSerializer deserializer = new XmlSerializer(typeof(result));
                       using (TextReader textReader = new StreamReader(files[i]))
                       {
                           r = (result)deserializer.Deserialize(textReader);
                       }
                       string p = Path.GetFileNameWithoutExtension(files[i]);
                       sb.AppendLine(String.Format("<p><h3>{0}, success:{1}%</h3></p>",p,r.success));
                       for (int j = 0; j < 10; j++)
                       {
                           sb.AppendLine(String.Format("<p>{0}. word was \"{1}\" ,its translation was \"{2}\" , and you answered \"{3}\".</p>", (j+1),r.questions[j],r.trues[j],r.answers[j]));
                       
                       }
                   
                   }

                   sb.AppendLine(" </div></div></div></div>");

                       html2 += sb.ToString();
               }
               private void html3_body()
               {

                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<body>");
                   sb.AppendLine("<div class=\"spinner\"></div>");
                   sb.AppendLine("<header>");
                   sb.AppendLine("<div class=\"container clearfix\">");
                   sb.AppendLine("<div class=\"row\">");
                   sb.AppendLine("<div class=\"span12\">");
                   sb.AppendLine("<div class=\"navbar navbar_\">");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine("<img  src=\"img/logor.png\" width=\"220 px\" height=\"150 px\" alt=\"Berk Arslan\">");
                   sb.AppendLine("<a class=\"btn btn-navbar btn-navbar_\" data-toggle=\"collapse\" data-target=\".nav-collapse_\">Menu <span class=\"icon-bar\"></span> </a>");
                   sb.AppendLine("<div class=\"nav-collapse nav-collapse_  collapse\">");
                   sb.AppendLine("<ul class=\"nav sf-menu\">");
                   sb.AppendLine(" <li><a href=\"index.html\">Home</a></li>");
                   sb.AppendLine(" <li ><a href=\"detail.html\">Details</a></li>");
                   sb.AppendLine(" <li class=\"active\"><a href=\"guide.html\">Guide</a></li>");
                   sb.AppendLine(" <li><a href=\"contact.html\">Contact</a></li>");
                   sb.AppendLine("</ul></div></div></div></div></div></div></header> ");
                   sb.AppendLine("<div class=\"bg-content\">");
                   sb.AppendLine("<div id=\"content\"><div class=\"ic\">Dictionary</div>");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine(" <div class=\"row\">");
                   sb.AppendLine("  <article class=\"span12\">");
                   sb.AppendLine("  <h3>User Guide</h3></article>");
                   sb.AppendLine(" <div class=\"clear\"></div>");
                   sb.AppendLine("<ul class=\"thumbnails thumbnails-1 list-services\">");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/1.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Main window:Login or Register.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/2.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Only english characters can be used.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/3.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Registration Form.All informations have to be provided.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/13.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Settings: You can choose template and color.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/4.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Dictionary translates words from english to russian.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/5.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>It is possible to select word or type one.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/6.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Error message if word cannot be found.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/7.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Starting to test. Please press \"Start\" button. </section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/8.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>This is how the test looks like.You can see if answer is correct or not. </section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/10.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>After test results if the result is bad.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/9.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>After test results if the result is not bad.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/11.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>After test results if the result is good.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/12.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>Result graph: show all the test results date by date.Mouse motions to bars activates those bars.Graph shows current data. If data is deleted from directory then graph will delete that bar.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/14.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>File title link gives an oppurtunity to make a report in desired formats,to create user guide and to clean results.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/15.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>If you select radio buttons (html,doc,docx), report will be created in the directory called \"Reports\".</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/16.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>User Guide can be found in directory 'Guide'. If you cannot find this directory or user guide this generator will create new one.</section></div></li>");
                   sb.AppendLine("<li class=\"span4c\">");
                   sb.AppendLine("<div class=\"thumbnail thumbnail-1\"> <img  src=\"img/user_guide/17.png\" alt=\"\" width=\"720\" height=\"450\">");
                   sb.AppendLine("<section>If you want to clean results, this section will clean directory for you.</section></div></li>");
                   sb.AppendLine("</ul></div></div></div></div>");





                   

                   sb.AppendLine(" </div></div></div></div>");

                   html3 += sb.ToString();
               }
               private void html4_body()
               {

                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<body>");
                   sb.AppendLine("<div class=\"spinner\"></div>");
                   sb.AppendLine("<header>");
                   sb.AppendLine("<div class=\"container clearfix\">");
                   sb.AppendLine("<div class=\"row\">");
                   sb.AppendLine("<div class=\"span12\">");
                   sb.AppendLine("<div class=\"navbar navbar_\">");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine("<img  src=\"img/logor.png\" width=\"220 px\" height=\"150 px\" alt=\"Berk Arslan\">");
                   sb.AppendLine("<a class=\"btn btn-navbar btn-navbar_\" data-toggle=\"collapse\" data-target=\".nav-collapse_\">Menu <span class=\"icon-bar\"></span> </a>");
                   sb.AppendLine("<div class=\"nav-collapse nav-collapse_  collapse\">");
                   sb.AppendLine("<ul class=\"nav sf-menu\">");
                   sb.AppendLine(" <li><a href=\"index.html\">Home</a></li>");
                   sb.AppendLine(" <li ><a href=\"detail.html\">Details</a></li>");
                     sb.AppendLine(" <li ><a href=\"guide.html\">Guide</a></li>");
                    sb.AppendLine(" <li class=\"active\"><a href=\"contact.html\">Contact</a></li>");
                   sb.AppendLine("</ul></div></div></div></div></div></div></header> ");
                   sb.AppendLine("<div class=\"bg-content\">");
                   sb.AppendLine("<div id=\"content\"><div class=\"ic\">Dictionary</div>");
                   sb.AppendLine("<div class=\"container\">");
                   sb.AppendLine(" <div class=\"row\">");
                   sb.AppendLine(" <article class=\"span8\">");
                   sb.AppendLine(" <h3>Contact Us</h3>");
                   sb.AppendLine("  <div class=\"inner-1\">");
                   sb.AppendLine(" <form id=\"contact-form\">");
                   sb.AppendLine("  <div class=\"success\"> Contact form submitted! <strong>We will be in touch soon.</strong> </div>");
                   sb.AppendLine(" <fieldset>");
                   sb.AppendLine("  <div>");
                   sb.AppendLine("  <label class=\"name\">");
                   sb.AppendLine(" <input type=\"text\" value=\"Your name\">");
                   sb.AppendLine("<br>");
                   sb.AppendLine("<span class=\"error\">*This is not a valid name.</span> <span class=\"empty\">*This field is required.</span> </label> </div>");
                   sb.AppendLine("<div>");
                   sb.AppendLine("<label class=\"phone\">");
                   sb.AppendLine("<input type=\"tel\" value=\"Telephone\">");
                   sb.AppendLine("<br>");
                   sb.AppendLine("<span class=\"error\">*This is not a valid phone number.</span> <span class=\"empty\">*This field is required.</span> </label></div>");
                   sb.AppendLine("<div>");
                   sb.AppendLine("<label class=\"email\">");
                   sb.AppendLine("<input type=\"email\" value=\"Email\">");
                   sb.AppendLine("<br><span class=\"error\">*This is not a valid email address.</span> <span class=\"empty\">*This field is required.</span> </label> </div>");
                   sb.AppendLine("<div>");
                   sb.AppendLine(" <label class=\"message\">");
                   sb.AppendLine(" <textarea>Message</textarea>");
                   sb.AppendLine(" <br><span class=\"error\">*The message is too short.</span> <span class=\"empty\">*This field is required.</span> </label> </div>");
                   sb.AppendLine("<div class=\"buttons-wrapper\"> <a class=\"btn btn-1\" data-type=\"reset\">Clear</a> <a class=\"btn btn-1\" data-type=\"submit\">Send</a></div>");
                   sb.AppendLine(" </fieldset></form></div></article>");
                   sb.AppendLine(" <article class=\"span4\">");
                   sb.AppendLine(" <h3>Contact info</h3>");
                   sb.AppendLine(" <address class=\"address-1\">");
                   sb.AppendLine(" <strong>Ukraine<br>");
                   sb.AppendLine(" Kharkiv</strong>");
                   sb.AppendLine("  <div class=\"overflow\"> <span>Telephone:</span>+38 093 939 22 97<br>");
                   sb.AppendLine("  <div class=\"overflow\"> <span>E-mail:</span>berk.arslan93@gmail.com<br>");
                   sb.AppendLine(" </div></address></article>");

                   sb.AppendLine(" </div></div></div></div>");

                   html4 += sb.ToString();
               }
               private void html_footer()
               {
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<footer>");
                   sb.AppendLine(" <div class=\"container clearfix\">");
                   sb.AppendLine(" <div class=\"privacy pull-left\">Copyright© 2014 <a href=\"#\" target=\"_blank\" rel=\"nofollow\">Berk Arslan</a> </div></div></footer>");
                   sb.AppendLine("<script type=\"text/javascript\" src=\"js/bootstrap.js\"></script>");
                   sb.AppendLine("</body></html>");

                   html += sb.ToString();


               }
               private void html2_footer()
               {
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<footer>");
                   sb.AppendLine(" <div class=\"container clearfix\">");
                   sb.AppendLine(" <div class=\"privacy pull-left\">Copyright© 2014 <a href=\"#\" target=\"_blank\" rel=\"nofollow\">Berk Arslan</a> </div></div></footer>");
                   sb.AppendLine("<script type=\"text/javascript\" src=\"js/bootstrap.js\"></script>");
                   sb.AppendLine("</body></html>");

                   html2 += sb.ToString();


               }
               private void html3_footer()
               {
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<footer>");
                   sb.AppendLine(" <div class=\"container clearfix\">");
                   sb.AppendLine(" <div class=\"privacy pull-left\">Copyright© 2014 <a href=\"#\" target=\"_blank\" rel=\"nofollow\">Berk Arslan</a> </div></div></footer>");
                   sb.AppendLine("<script type=\"text/javascript\" src=\"js/bootstrap.js\"></script>");
                   sb.AppendLine("</body></html>");

                   html3 += sb.ToString();


               }
               private void html4_footer()
               {
                   StringBuilder sb = new StringBuilder();
                   sb.AppendLine("<footer>");
                   sb.AppendLine(" <div class=\"container clearfix\">");
                   sb.AppendLine(" <div class=\"privacy pull-left\">Copyright© 2014 <a href=\"#\" target=\"_blank\" rel=\"nofollow\">Berk Arslan</a> </div></div></footer>");
                   sb.AppendLine("<script type=\"text/javascript\" src=\"js/bootstrap.js\"></script>");
                   sb.AppendLine("</body></html>");

                   html4 += sb.ToString();


               }
               private void html_write()
               {
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Reports\\html\\", dir);
                  
                   StreamWriter sw = new StreamWriter(path+"index.html");
                   sw.Flush();
                   sw.Write(html);
                   sw.Close(); 
               }
               private void html2_write()
               {
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Reports\\html\\", dir);

                   StreamWriter sw = new StreamWriter(path + "detail.html");
                   sw.Flush();
                   sw.Write(html2);
                   sw.Close();
               }
               private void html3_write()
               {
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Reports\\html\\",dir);

                   StreamWriter sw = new StreamWriter(path + "guide.html");
                   sw.Flush();
                   sw.Write(html3);
                   sw.Close();
               }
               private void html4_write()
               {
                   String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Reports\\html\\", dir);

                   StreamWriter sw = new StreamWriter(path + "contact.html");
                   sw.Flush();
                   sw.Write(html4);
                   sw.Close();
               }

               public void docx()
               {
                   try{
                       String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                       dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Reports\\docx\\", dir);
                   string path_img = string.Format("{0}Images\\graph.png", dir);

                   if (!Directory.Exists(path))
                   {
                       Directory.CreateDirectory(path);
                   }
                   var doc = DocX.Create(path+"report.docx");
                   //Headline
                   var headLineFormat = new Formatting();
                //   headLineFormat.FontFamily =new FontFamily("Times New Roman");
                   headLineFormat.Size = 14D;
                   headLineFormat.Position = 12;
                   headLineFormat.Bold = true;
                   //text
                   var textLineFormat = new Formatting();
                   textLineFormat.Size = 14D;
                   textLineFormat.Position = 12;
                   textLineFormat.Bold = false;
                   //header

                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("MINISTRY OF EDUCATION AND SCIENCE OF UKRAINE NATIONAL TECHNICAL ", false, headLineFormat);
                   doc.InsertParagraph("       UNIVERSITY «KHARKIV POLITECNIC INSTITUTE» DEPARTMENT OF",false,headLineFormat);
                   doc.InsertParagraph("                            COMPUTER-AIDED MANAGMENT SYSTEMS", false, headLineFormat);

                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");                 
                   doc.InsertParagraph("                                                     Course Work ", false, headLineFormat);
                   doc.InsertParagraph("                         on course: << Object Oriented Programming>> ", false, headLineFormat);
                   doc.InsertParagraph("                          entitled: << Wpf Applications \"Dictionary\">> ", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph(""); 
                   doc.InsertParagraph("                                                                                                          Performer:", false, headLineFormat);
                   doc.InsertParagraph("                                                                                                          Berk Arslan", false, headLineFormat);
                   doc.InsertParagraph("                                                                                                          If-32 j", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("                                                              Kharkiv 2014                                ",false,headLineFormat);

                   //title1
                   doc.InsertParagraph("1.Graph Results",false,headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("    Graph 1.1 shows results according to stored data \"Results\".   ",false,textLineFormat);

                    //creating image
                   using (MemoryStream ms = new MemoryStream())
                   {
                       
                       

                       Novacode.Image img = doc.AddImage(path_img); // Create image.

                       Novacode.Paragraph p = doc.InsertParagraph("", false);

                       Picture pic1 = img.CreatePicture();     // Create picture.
                      // pic1.SetPictureShape(BasicShapes.plus); // Set picture shape (if needed)

                       p.InsertPicture(pic1,0); // Insert picture into paragraph.

                     
                   }
                   doc.InsertParagraph("");

                   doc.InsertParagraph("                                                                     graph 1.1 - Results");

                   doc.InsertParagraph("");
                   username u = new username();
                   string name;
                   u.reader(out name);
                   doc.InsertParagraph(String.Format("    According to these result you can see the progress day by day. This graph is directly created by dictionary program to provide feedbacks due to test has been done by {0}.",name),false,textLineFormat);

                   doc.InsertParagraph("");
                   doc.InsertParagraph("2.Result Details", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("  Here there is shown detailed results due to questions and their answers. This comparison will help you to understand exactly which questions were wrong. ", false, textLineFormat);
                   doc.InsertParagraph("");

                   string path_rslt = string.Format("{0}Results\\", dir);
                   string[] files = Directory.GetFiles(path_rslt);
                   for (int i = 0; i < files.Count(); i++)
                   {
                       result r = new result();
                       XmlSerializer deserializer = new XmlSerializer(typeof(result));
                       using (TextReader textReader = new StreamReader(files[i]))
                       {
                           r = (result)deserializer.Deserialize(textReader);
                       }
                       string p = Path.GetFileNameWithoutExtension(files[i]);
                       doc.InsertParagraph(String.Format("{0}, success:{1}%", p, r.success), false, headLineFormat);
                       for (int j = 0; j < 10; j++)
                       {
                           doc.InsertParagraph(String.Format("{0}. word was \"{1}\" ,its translation was \"{2}\" , and you answered \"{3}\".", (j + 1), r.questions[j], r.trues[j], r.answers[j]),false,textLineFormat);

                       }
                       doc.InsertParagraph("");
                   }
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("3.Conclusion",false,headLineFormat);
                   doc.InsertParagraph("");
                   string text = "    Dictionary program presented graphical presentation of results and detailed results which include questions and their answers with user answers.If success rate is less than 50% then it means result is bad, and average result is between 50-80 %, if success is greater than 80% then it means the result is very good.";
                   doc.InsertParagraph(text,false,textLineFormat);

                   doc.Save();
                    }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
               
               }
               public void doc()
               {
                   try{
                       String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                       dir += "\\ArslanSoftware\\";
                   string path = string.Format("{0}Reports\\doc\\",dir);
                   string path_img = string.Format("{0}Images\\graph.png",dir);

                   if (!Directory.Exists(path))
                   {
                       Directory.CreateDirectory(path);
                   }
                   var doc = DocX.Create(path + "report.doc");
                   //Headline
                   var headLineFormat = new Formatting();
                   //   headLineFormat.FontFamily =new FontFamily("Times New Roman");
                   headLineFormat.Size = 14D;
                   headLineFormat.Position = 12;
                   headLineFormat.Bold = true;
                   //text
                   var textLineFormat = new Formatting();
                   textLineFormat.Size = 14D;
                   textLineFormat.Position = 12;
                   textLineFormat.Bold = false;
                   //header

                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("MINISTRY OF EDUCATION AND SCIENCE OF UKRAINE NATIONAL TECHNICAL ", false, headLineFormat);
                   doc.InsertParagraph("       UNIVERSITY «KHARKIV POLITECNIC INSTITUTE» DEPARTMENT OF", false, headLineFormat);
                   doc.InsertParagraph("                            COMPUTER-AIDED MANAGMENT SYSTEMS", false, headLineFormat);

                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("                                                     Course Work ", false, headLineFormat);
                   doc.InsertParagraph("                         on course: << Object Oriented Programming>> ", false, headLineFormat);
                   doc.InsertParagraph("                          entitled: << Wpf Applications \"Dictionary\">> ", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("                                                                                                          Performer:", false, headLineFormat);
                   doc.InsertParagraph("                                                                                                          Berk Arslan", false, headLineFormat);
                   doc.InsertParagraph("                                                                                                          If-32 j", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("                                                              Kharkiv 2014                                ", false, headLineFormat);

                   //title1
                   doc.InsertParagraph("1.Graph Results", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("    Graph 1.1 shows results according to stored data \"Results\".   ", false, textLineFormat);

                   //creating image
                   using (MemoryStream ms = new MemoryStream())
                   {



                       Novacode.Image img = doc.AddImage(path_img); // Create image.

                       Novacode.Paragraph p = doc.InsertParagraph("", false);

                       Picture pic1 = img.CreatePicture();     // Create picture.
                       // pic1.SetPictureShape(BasicShapes.plus); // Set picture shape (if needed)

                       p.InsertPicture(pic1, 0); // Insert picture into paragraph.


                   }
                   doc.InsertParagraph("");

                   doc.InsertParagraph("                                                                     graph 1.1 - Results");

                   doc.InsertParagraph("");
                   username u = new username();
                   string name;
                   u.reader(out name);
                   doc.InsertParagraph(String.Format("    According to these result you can see the progress day by day. This graph is directly created by dictionary program to provide feedbacks due to test has been done by {0}.", name), false, textLineFormat);

                   doc.InsertParagraph("");
                   doc.InsertParagraph("2.Result Details", false, headLineFormat);
                   doc.InsertParagraph("");
                   doc.InsertParagraph("  Here there is shown detailed results due to questions and their answers. This comparison will help you to understand exactly which questions were wrong. ", false, textLineFormat);
                   doc.InsertParagraph("");

                   string path_rslt = string.Format("{0}Results\\", dir);
                   string[] files = Directory.GetFiles(path_rslt);
                   for (int i = 0; i < files.Count(); i++)
                   {
                       result r = new result();
                       XmlSerializer deserializer = new XmlSerializer(typeof(result));
                       using (TextReader textReader = new StreamReader(files[i]))
                       {
                           r = (result)deserializer.Deserialize(textReader);
                       }
                       string p = Path.GetFileNameWithoutExtension(files[i]);
                       doc.InsertParagraph(String.Format("{0}, success:{1}%", p, r.success), false, headLineFormat);
                       for (int j = 0; j < 10; j++)
                       {
                           doc.InsertParagraph(String.Format("{0}. word was \"{1}\" ,its translation was \"{2}\" , and you answered \"{3}\".", (j + 1), r.questions[j], r.trues[j], r.answers[j]), false, textLineFormat);

                       }
                       doc.InsertParagraph("");
                   }
                   doc.InsertParagraph("");
                   doc.InsertParagraph("");
                   doc.InsertParagraph("3.Conclusion", false, headLineFormat);
                   doc.InsertParagraph("");
                   string text = "    Dictionary program presented graphical presentation of results and detailed results which include questions and their answers with user answers.If success rate is less than 50% then it means result is bad, and average result is between 50-80 %, if success is greater than 80% then it means the result is very good.";
                   doc.InsertParagraph(text, false, textLineFormat);

                   doc.Save();
                    }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

               }
              
    }
}
