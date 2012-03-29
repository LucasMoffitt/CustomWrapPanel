using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomWrapPanel 
{
    public class CustomPanel : WrapPanel
    {
        public bool PanelFull { get; private set; }
        
        public void AddControl(dynamic item)
        {           
            Children.Add(item);
            UpdateLayout();
        }     
        
        protected override Size ArrangeOverride(Size arrangeBounds) 
        {
            int firstInLine = 0;
            Size curLineSize = new Size();
            double accumulatedHeight = 0;

            UIElementCollection children = InternalChildren;

            for(int i = 0; i < children.Count; i++) 
            {
                Size sz = children[i].DesiredSize;
                               
                if(curLineSize.Width + sz.Width > arrangeBounds.Width) 
                {
                    arrangeLine(accumulatedHeight, curLineSize.Height, firstInLine, i);

                    accumulatedHeight += curLineSize.Height;
                    curLineSize = sz;

                    if(sz.Width > arrangeBounds.Width)               
                    {
                        arrangeLine(accumulatedHeight, sz.Height, i, ++i);
                        accumulatedHeight += sz.Height;
                        curLineSize = new Size();
                    }
                    firstInLine = i;
                } 
                else 
                {
                    curLineSize.Width += sz.Width;
                    curLineSize.Height = Math.Max(sz.Height, curLineSize.Height);
                }

                if(accumulatedHeight + sz.Height > ActualHeight) 
                {
                    PanelFull = true;
                }
            }    
            return arrangeBounds;
        }

        private void arrangeLine(double y, double lineHeight, int start, int end) 
        {
            double x = 0;
            UIElementCollection children = InternalChildren;
            for(int i = start; i < end; i++) 
            {
                UIElement child = children[i];
                child.Arrange(new Rect(x, y, child.DesiredSize.Width, lineHeight));
                x += child.DesiredSize.Width;
            }
        }
    }
}
