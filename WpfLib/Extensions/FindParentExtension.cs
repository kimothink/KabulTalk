using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfLib.Extensions
{
    public static class FindParentExtension
    {
        public static T? FindParent<T>(this DependencyObject chiled)
        where T : DependencyObject
        {
            return FindParent<T>(chiled, null);
        }

        public static T? FindParent<T>(this DependencyObject chiled, string? parentName)
        where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(chiled);
            if (parent == null)
            {
                return null;
            } 

            var freameworkElement = (FrameworkElement)parent;
            if ((parentName == null || freameworkElement.Name == parentName) && freameworkElement is T)
            {
                return (T)parent;
            }
            else
            {
                return FindParent<T>(parent, parentName);
            }

        }
    }
}
