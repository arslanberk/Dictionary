using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;


namespace Dictionary
{
    class userGuide
    {
        private string html3;
        public userGuide()
        { }
        public void html3_report()
        {
            try {
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
                string src = string.Format("{0}css\\", AppDomain.CurrentDomain.BaseDirectory);
            string path = string.Format("{0}Guide\\css\\",dir);
            DirectoryCopy(src, path, true);
            string src2 = string.Format("{0}js\\", AppDomain.CurrentDomain.BaseDirectory);
            string path2 = string.Format("{0}Guide\\js\\", dir);
            DirectoryCopy(src2, path2, true);
            string src3 = string.Format("{0}Images\\", AppDomain.CurrentDomain.BaseDirectory);
            string path3 = string.Format("{0}Guide\\img\\",dir);
            DirectoryCopy(src3, path3, true);
            guide_header();
            guide_body();
            guide_footer();
            guide_write(); }
            catch(Exception exc)
            { MessageBox.Show(exc.Message); }
            
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
        private void guide_header()
        {
            username u = new username();
            string name;
            u.reader(out name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("<!DOCTYPE html>\n<html lang=\"en\">\n"));
            sb.AppendLine(String.Format("<head>\n<title>Report for {0}</title>\n<meta charset=\"utf-8\">\n<link rel=\"icon\" href=\"img/icon.ico\" type=\"image/x-icon\">\n<link rel=\"shortcut icon\" href=\"img/icon.ico\" type=\"image/x-icon\" />", name));

            string img = string.Format("{0}Images", AppDomain.CurrentDomain.BaseDirectory);
            string path = string.Format("{0}Reports\\html\\img", AppDomain.CurrentDomain.BaseDirectory);
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
        private void guide_body()
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
            sb.AppendLine(" <li class=\"active\"><a href=\"guide.html\">Guide</a></li>");
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
            sb.AppendLine("<section>File title link gives an oppurtunity to make a report in desired formats.</section></div></li>");
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
        private void guide_footer()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<footer>");
            sb.AppendLine(" <div class=\"container clearfix\">");
            sb.AppendLine(" <div class=\"privacy pull-left\">Copyright© 2014 <a href=\"#\" target=\"_blank\" rel=\"nofollow\">Berk Arslan</a> </div></div></footer>");
            sb.AppendLine("<script type=\"text/javascript\" src=\"js/bootstrap.js\"></script>");
            sb.AppendLine("</body></html>");

            html3 += sb.ToString();


        }

        private void guide_write()
        {
            try
            {
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
                string path = string.Format("{0}Guide\\", dir);

                StreamWriter sw = new StreamWriter(path + "guide.html");
                sw.Flush();
                sw.Write(html3);
                sw.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
