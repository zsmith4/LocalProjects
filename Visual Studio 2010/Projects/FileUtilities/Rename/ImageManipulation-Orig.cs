//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace FileUtilities
//{
//    class ImageManipulationOrig
//    {
//        //maybe Option1
//        public static byte[] ResizeImageFile(byte[] imageFile, int targetSize) // Set targetSize to 1024 
//        {
//            using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
//            {
//                Size newSize = CalculateDimensions(oldImage.Size, targetSize);
//                using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb))
//                {
//                    using (Graphics canvas = Graphics.FromImage(newImage))
//                    {
//                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
//                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
//                        canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
//                        MemoryStream m = new MemoryStream();
//                        newImage.Save(m, ImageFormat.Jpeg);
//                        return m.GetBuffer();
//                    }
//                }
//            }
//        }

//        public static Size CalculateDimensions(Size oldSize, int targetSize)
//        {
//            Size newSize = new Size();
//            if (oldSize.Height > oldSize.Width)
//            {
//                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
//                newSize.Height = targetSize;
//            }
//            else
//            {
//                newSize.Width = targetSize;
//                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
//            }
//            return newSize;
//        }

//        //maybe Option2
//        public void FitImage(string pPath, int pNewWidth, int pMaxHeight, string pNewName)
//        {
//            ImageCodecInfo iciJpegCodec = null;
//            string pFileName = "OldName"; //I added this

//            Image FullsizeImage = Image.FromFile(pPath + pFileName);

//            // Prevent using images internal thumbnail
//            FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
//            FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

//            int NewHeight = FullsizeImage.Height * pNewWidth / FullsizeImage.Width;
//            if (NewHeight > pMaxHeight)
//            {
//                // Resize with height instead
//                pNewWidth = FullsizeImage.Width * pMaxHeight / FullsizeImage.Height;
//                NewHeight = pMaxHeight;
//            }

//            //find the correct Codec and specify its quality
//            EncoderParameter epQuality = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 80);
//            // Get all image codecs that are available
//            ImageCodecInfo[] iciCodecs = ImageCodecInfo.GetImageEncoders();
//            // Store the quality parameter in the list of encoder parameters
//            EncoderParameters epParameters = new EncoderParameters(1);
//            epParameters.Param[0] = epQuality;
//            // Loop through all the image codecs
//            for (int i = 0; i < iciCodecs.Length; i++)
//            {
//                // Until the one that we are interested in is found, which is image/jpeg
//                if (iciCodecs[i].MimeType == "image/jpeg")
//                {
//                    iciJpegCodec = iciCodecs[i];
//                    break;
//                }
//            }

//            Bitmap bmp = new Bitmap(pNewWidth, NewHeight,PixelFormat.Format24bppRgb);
//            using (Graphics gr = Graphics.FromImage(bmp))
//                gr.DrawImage(FullsizeImage, new Rectangle(0, 0, bmp.Width, bmp.Height));

//            // Save resized picture
//            //bmp.Save(pPath + pNewName, iciJpegCodec, epParameters);
//            bmp.Save(pPath + pNewName, ImageFormat.Jpeg);

//            //bmp.Dispose();
//        }

//        #region These are together
//        public class ImageEditingOld
//        {
//            private static string originalPath;

//            /// <summary>
//            /// Initializes a new instance of the ImageEditing class
//            /// </summary>
//            /// <param name="path">To store image original path</param>
//            public ImageEditingOld(string path)
//            {
//                originalPath = path;
//            }

//            /// <summary>
//            /// To resize images to different sizes
//            /// </summary>
//            /// <param name="width">image width</param>
//            /// <param name="height">image height </param>
//            /// <returns>resized image</returns>
//            public Image Resize(int width, int height)
//            {
//                return Resize(width, height, Image.FromFile(originalPath));
//            }

//            /// <summary>
//            /// To resize image with respect to given ratio.
//            /// </summary>
//            /// <param name="ratio">ratio of the image.</param>
//            /// <param name="path">source of the image.</param>
//            /// <returns>resized ratio of the image</returns>
//            public Image Resize(int ratio)
//            {
//                Image tempimage = Image.FromFile(originalPath);
//                return Resize((int)(tempimage.Width * 0.01 * ratio), (int)(tempimage.Height * 0.01 * ratio), Image.FromFile(originalPath));
//            }

//            /// <summary>
//            /// To resize images to different sizes
//            /// </summary>
//            /// <param name="width">Image width</param>
//            /// <param name="height">image width </param>
//            /// <param name="path">path(url) of the image </param>
//            /// <returns>resized image</returns>
//            public Image Resize(int width, int height, string path)
//            {
//                return Resize(width, height, Image.FromFile(path));
//            }

//            /// <summary>
//            /// To resize images to different sizes
//            /// </summary>
//            /// <param name="width">image width</param>
//            /// <param name="height">image height</param>
//            /// <param name="image">image informations</param>
//            /// <returns>resized image</returns>
//            public Image Resize(int width, int height, Image image)
//            {
//                decimal HeigthWidthRatio = (decimal)image.Height / (decimal)image.Width;

//                if (width > image.Width)
//                {
//                    width = image.Width;
//                }

//                if ((decimal)image.Width / width > (decimal)image.Height / height)
//                {
//                    height = (int)((decimal)width * HeigthWidthRatio);
//                }
//                else
//                {
//                    width = (int)((decimal)height / HeigthWidthRatio);
//                }

//                return GetResizedImage(width, height, image);
//            }

//            /// <summary>
//            /// To geneterate thumbnail image
//            /// </summary>
//            /// <param name="width">image width</param>
//            /// <param name="height"> image height</param>
//            /// <param name="image"> image informations</param>
//            /// <returns>thumbnail image</returns>
//            private Image GetResizedImage(int width, int height, Image image)
//            {
//                if (width <= 0 | height <= 0)
//                {
//                    throw new Exception("Either width or heigth has invalid value");
//                }

//                try
//                {
//                    Image ThumbNail = new Bitmap(width, height, image.PixelFormat);
//                    Graphics Graphic = Graphics.FromImage(ThumbNail);

//                    Graphic.CompositingQuality = CompositingQuality.HighQuality;
//                    Graphic.SmoothingMode = SmoothingMode.HighQuality;
//                    Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

//                    Rectangle Rectangle = new Rectangle(0, 0, width, height);
//                    Graphic.DrawImage(image, Rectangle);

//                    return ThumbNail;

//                }
//                catch (Exception e)
//                {
//                    throw new Exception(e.Message);
//                }
//                finally
//                {
//                    image.Dispose();
//                }
//            }
//        }

//#endregion

//        #region Probably not

//        //avoid using thumbnail
//        //public void ResizeImage(double scaleFactor, Stream fromStream, Stream toStream)
//        //{
//        //    var image = Image.FromStream(fromStream);
//        //    var width = (int)(image.Width * scaleFactor);
//        //    var height = (int)(image.Height * scaleFactor);
//        //    var thumbnailBitmap = new Bitmap(width, height);
//        //    var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
//        //    thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
//        //    thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
//        //    thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
//        //    var imageRectangle = new Rectangle(0, 0, width, height);
//        //    thumbnailGraph.DrawImage(image, imageRectangle);
//        //    thumbnailBitmap.Save(toStream, image.RawFormat);
//        //    thumbnailGraph.Dispose();
//        //    thumbnailBitmap.Dispose();
//        //    image.Dispose();

//        //}

//        //public void vbScaling(Image img)
//        //{
//        //    float scaleFactor;
//        //    if (img.Width >= img.Height)
//        //    {

//        //        scaleFactor = (100 / img.Width);
//        //    }
//        //    else
//        //    {
//        //        scaleFactor = (100 / img.Height);
//        //    }

//        //    float width = img.Width * scaleFactor;
//        //    float height = img.Height * scaleFactor;

//        //}

//        //public void AnotherOption()
//        //{
//        //    var encoderParams = new EncoderParameters();
//        //    var quality = new long[1];
//        //    quality[0] = 75;
//        //    var encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
//        //    encoderParams.Param[0] = encoderParam;
//        //    ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

//        //    //bitmap2.Save(HttpContext.Current.Server.MapPath(strfilename), encoders[1], encoderParams);

//        //}		
//        #endregion Probably Not
        
//        #region Image rotate
//        public static void RotateFlipInPlace(string path, RotateFlipType rotateFlipType)
//        {
//            var image = Image.FromFile(path);
//            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
//            image.Save(path, ImageFormat.Jpeg);
//        }
//        #endregion

//    }
//}
