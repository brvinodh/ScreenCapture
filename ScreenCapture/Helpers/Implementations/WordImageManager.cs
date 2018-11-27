using Microsoft.Office.Interop.Word;
using ScreenCapture.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Helpers.Implementations
{
    internal class WordImageManager : IImageManager
    {
        /// <summary>
        /// Represents a word application
        /// </summary>
        private Microsoft.Office.Interop.Word.Application WordApp = null;


        /// <summary>
        /// The word document
        /// </summary>
        private Microsoft.Office.Interop.Word.Document wordDocument = null;

        private object documentPath;

        private IImageFileHelper fileHelper;

        private IMessageBox messageBox;

        public WordImageManager(IMessageBox messageBox, IImageFileHelper fileHelper)
        {
            this.fileHelper = fileHelper;
            this.messageBox = messageBox;

        }

        public void AddImageToDocument(string image)
        {
            this.SaveToWord(image);
        }

        public void CreateNewDocument()
        {
            this.OpenDoc(this.fileHelper.GetWordFileName(), true);
        }

        public void OpenDocument(string fileName)
        {
            this.OpenDoc(fileName);
        }

        private void OpenDoc(string fileName, bool createNew = false)
        {
            this.WordApp = new Microsoft.Office.Interop.Word.Application();
            //Create a missing variable for missing value
            object missing = System.Reflection.Missing.Value;
            object obj = fileName;
            //Create a new document
            Microsoft.Office.Interop.Word.Document document = null;//this.WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            if (createNew)
            {
                document= this.WordApp.Documents.Add(ref missing, ref missing, ref missing);
            }
            else
            {
                document = this.WordApp.Documents.Open(ref obj, ref missing, ref missing, ref missing);
            }

            //this.WordApp.Documents.Open(ref obj, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value);
            this.WordApp.Visible = true;
            this.wordDocument = this.WordApp.ActiveDocument;
            this.documentPath = fileName;
        }

        public void SaveToWord(string image)
        {
            if (this.wordDocument != null)
            {
                object obj = WdGoToItem.wdGoToLine;
                object obj1 = WdGoToDirection.wdGoToLast;
                Document document = this.wordDocument;
                object missing = Type.Missing;
                object missing1 = Type.Missing;
                document.GoTo(ref obj, ref obj1, ref missing, ref missing1);
                Selection selection = this.WordApp.Selection;
                object obj2 = WdUnits.wdStory;
                object value = System.Reflection.Missing.Value;
                selection.EndKey(ref obj2, ref value);
                InlineShapes inlineShapes = this.wordDocument.InlineShapes;
                object missing2 = Type.Missing;
                object missing3 = Type.Missing;
                object obj3 = Type.Missing;
                inlineShapes.AddPicture(image, ref missing2, ref missing3, ref obj3);
                Document document1 = this.wordDocument;
                object obj4 = this.documentPath;
                object missing4 = Type.Missing;
                object missing5 = Type.Missing;
                object obj5 = Type.Missing;
                object missing6 = Type.Missing;
                object obj6 = Type.Missing;
                object missing7 = Type.Missing;
                object obj7 = Type.Missing;
                object missing8 = Type.Missing;
                object obj8 = Type.Missing;
                object missing9 = Type.Missing;
                object obj9 = Type.Missing;
                object missing10 = Type.Missing;
                object obj10 = Type.Missing;
                object missing11 = Type.Missing;
                object obj11 = Type.Missing;
                document1.SaveAs(ref obj4, ref missing4, ref missing5, ref obj5, ref missing6, ref obj6, ref missing7, ref obj7, ref missing8, ref obj8, ref missing9, ref obj9, ref missing10, ref obj10, ref missing11, ref obj11);
            }
        }

        public void CloseDocument()
        {
            try
            {
                this.wordDocument.Close();                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
