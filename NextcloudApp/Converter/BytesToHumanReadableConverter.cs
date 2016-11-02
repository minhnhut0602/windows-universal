﻿using System;
using Windows.UI.Xaml.Data;
using NextcloudClient.Types;

namespace NextcloudApp.Converter
{
    public class BytesToHumanReadableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var size = decimal.Parse(((long)value).ToString());
            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            var order = 0;
            while (size >= 1024m && ++order < sizes.Length)
            {
                size = size / 1024m;
            }

            switch (order)
            {
                case 0:
                    return string.Format("{0:0} {1}", size, sizes[order]);

                case 1:
                    return string.Format("{0:0.#} {1}", size, sizes[order]);

                case 2:
                    return string.Format("{0:0.##} {1}", size, sizes[order]);
            }
            return string.Format("{0:0.###} {1}", size, sizes[order]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new ResourceInfo();
        }
    }
}
