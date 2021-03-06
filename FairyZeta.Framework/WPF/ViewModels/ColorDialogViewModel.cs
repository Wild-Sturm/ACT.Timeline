﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace FairyZeta.Framework.WPF.ViewModels
{
    public class ColorDialogViewModel : _ViewModel
    {
        #region #- [Property] PredefinedColor[].PredefinedColors - ＜カラーリスト一覧＞ -----
        /// <summary> カラーリスト一覧 </summary>
        private PredefinedColor[] _PredefinedColors;
        /// <summary> カラーリスト一覧 </summary>    
        public PredefinedColor[] PredefinedColors
        {
            get { return this._PredefinedColors ?? (this._PredefinedColors = this.EnumlatePredefinedColors()); }
            set { this.SetProperty(ref this._PredefinedColors, value); }
        }
        #endregion

        private PredefinedColor[] EnumlatePredefinedColors()
        {
            var colors = typeof(Colors).GetProperties();

            var list = new List<PredefinedColor>();
            foreach (var color in colors)
            {
                try
                {
                    list.Add(new PredefinedColor()
                    {
                        Name = color.Name,
                        Color = (Color)ColorConverter.ConvertFromString(color.Name)
                    });
                }
                catch
                {
                }
            }

            return list.OrderBy(x => x.Color.ToString()).ToArray();
        }
    }

    public class PredefinedColor
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
