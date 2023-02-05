using OpenCvSharp;
using System;

namespace OpenCV
{
    public partial class Default : System.Web.UI.Page
    {
        public bool ok { get; private set; } = false;

        protected void Page_PreRender(object sender, EventArgs e) => Page.DataBind();

        protected void Process_Click(object sender, EventArgs e)
        {
            if (!file1.HasFile || !file2.HasFile)
                return;

            var start = DateTime.Now;

            //Leo las imágenes
            //Reading the images
            using Mat sourceImage = Mat.FromStream(file1.FileContent, ImreadModes.Grayscale);
            using Mat sourceImage2 = Mat.FromStream(file2.FileContent, ImreadModes.Grayscale);

            int width = sourceImage.Width;
            int height = sourceImage.Height;

            if (width != sourceImage2.Width || height != sourceImage2.Height)
            {
                Response.Write("<span style=\"color:red\">Las imágenes deben tener el mismo tamaño</span><br/><br/>");
                return;
            }

            //Binarizo la primer imágen
            //Binarize the first image
            using Mat sourceImageGauss = new();
            Cv2.Threshold(sourceImage, sourceImageGauss, 0, 255, ThresholdTypes.Triangle | ThresholdTypes.Binary);
            sourceImageGauss.SaveImage(Server.MapPath("~/comp1-out.jpg"));

            //Binarizo la segunda imágen
            //Binarize the second image
            using Mat sourceImage2Gauss = new();
            Cv2.Threshold(sourceImage2, sourceImage2Gauss, 0, 255, ThresholdTypes.Triangle | ThresholdTypes.Binary);
            sourceImage2Gauss.SaveImage(Server.MapPath("~/comp2-out.jpg"));

            //Comparo las imágenes
            //Compare the images
            using Mat resultImage = new();
            Cv2.Absdiff(sourceImage2Gauss, sourceImageGauss, resultImage);

            //Guardo la imagen resultante
            //I save the resulting image
            resultImage.SaveImage(Server.MapPath("~/comp-out.jpg"));

            //Muestro los valores resultantes
            //I show the resulting values
            double diff = Cv2.CountNonZero(resultImage);
            Response.Write(string.Format("{0} píxeles distintos - las imágenes tienen una similitud del {1:P3}<br>", diff, 1 - (diff / (width * height))));
            Response.Write("<br>");
            Response.Write(DateTime.Now - start);
            Response.Write("<hr>");
            ok = true;
        }
    }
}