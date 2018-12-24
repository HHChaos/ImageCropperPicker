﻿using HHChaosToolkit.UWP.Mvvm;
using ImageCropperPicker.Models;
using System;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace ImageCropperPicker.ViewModels
{
    public class ImageCropperPickerViewModel : ObjectPickerBase<WriteableBitmap>
    {
        private WriteableBitmap _sourceImage;
        public WriteableBitmap SourceImage
        {
            get => _sourceImage;
            set => Set(ref _sourceImage, value);
        }
        private double _aspectRatio;
        public double AspectRatio
        {
            get => _aspectRatio;
            set => Set(ref _aspectRatio, value);
        }
        private bool _circularCrop;
        public bool CircularCrop
        {
            get => _circularCrop;
            set => Set(ref _circularCrop, value);
        }
        public async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ImageCropperConfig config)
            {
                var writeableBitmap = new WriteableBitmap(1, 1);
                using (var stream = await config.ImageFile.OpenReadAsync())
                {
                    await writeableBitmap.SetSourceAsync(stream);
                }

                SourceImage = writeableBitmap;
                AspectRatio = config.AspectRatio;
                CircularCrop = config.CircularCrop;
            }
            base.OnNavigatedTo(e);
        }
    }
}
