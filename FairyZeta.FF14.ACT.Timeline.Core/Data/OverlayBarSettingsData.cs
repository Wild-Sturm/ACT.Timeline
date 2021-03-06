﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイ各種バー設定データ
    /// </summary>
    [Serializable]
    public class OverlayBarSettingsData : _Data
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.BindOnColorChenged - ＜バインド用カラー変更フラグ＞ -----
        /// <summary> バインド用カラー変更フラグ </summary>
        private Color _BindOnColorChenged;
        /// <summary> バインド用カラー変更フラグ </summary>    
        [XmlIgnore]
        public Color BindOnColorChenged
        {
            get { return _BindOnColorChenged; }
            set { this.SetProperty(ref this._BindOnColorChenged, value); }
        }
        #endregion

        /// <summary> (バインド用)カスタム配色プロパティ </summary>    
        [XmlIgnore]
        public Color EditBindColor
        {
            get { return this.getEditTargetColor(); }
            set 
            {
                this.setEditTargetColor(value);
                this.BindOnColorChenged = value;
            }
        }

        #region #- [Property] ColorEditTarget.ColorEditTarget - ＜カラー変更ターゲット＞ -----
        /// <summary> カラー変更ターゲット </summary>
        private ColorEditTarget _ColorEditTarget;
        /// <summary> カラー変更ターゲット </summary>
        [XmlIgnore]
        public ColorEditTarget ColorEditTarget
        {
            get { return _ColorEditTarget; }
            set
            {
                this.SetProperty(ref this._ColorEditTarget, value);
                base.OnPropertyChanged("EditBindColor");
            }
        }
        #endregion

        #region #- [Property] BarFormType.BarFormType - ＜バー形状＞ -----
        /// <summary> バー形状 </summary>
        private BarFormType _BarFormType;
        /// <summary> バー形状 </summary>    
        public BarFormType BarFormType
        {
            get { return _BarFormType; }
            set 
            {
                this.SetProperty(ref this._BarFormType, value);
                base.SaveChangedTarget = true; 
            }
        }
        #endregion

        #region #- [Property] Thickness.BarMargin - ＜バーの余白＞ -----
        /// <summary> バー余白 </summary>
        private Thickness _BarMargin;
        /// <summary> バー余白 </summary>    
        public Thickness BarMargin
        {
            get { return _BarMargin; }
            set
            {
                this.SetProperty(ref this._BarMargin, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region -- Thickness 変更用 -----

        /// <summary> バー余白 </summary> 
        [XmlIgnore]
        public double BarMargin_Left
        {
            get { return this.BarMargin.Left; }
            set
            {
                this.BarMargin = new Thickness(value, BarMargin.Top, BarMargin.Right, BarMargin.Bottom);
            }
        }
        /// <summary> バー余白 </summary> 
        [XmlIgnore]
        public double BarMargin_Top
        {
            get { return this.BarMargin.Top; }
            set
            {
                this.BarMargin = new Thickness(BarMargin.Left, value, BarMargin.Right, BarMargin.Bottom);
            }
        }
        /// <summary> バー余白 </summary> 
        [XmlIgnore]
        public double BarMargin_Right
        {
            get { return this.BarMargin.Right; }
            set
            {
                this.BarMargin = new Thickness(BarMargin.Left, BarMargin.Top, value, BarMargin.Bottom);
            }
        }
        /// <summary> バー余白 </summary> 
        [XmlIgnore]
        public double BarMargin_Bottom
        {
            get { return this.BarMargin.Bottom; }
            set
            {
                this.BarMargin = new Thickness(BarMargin.Left, BarMargin.Top, BarMargin.Right, value);
            }
        }

        /// <summary> バー内部の余白 </summary> 
        [XmlIgnore]
        public double BarInnerMargin_Left
        {
            get { return this.BarInnerMargin.Left; }
            set
            {
                this.BarInnerMargin = new Thickness(value, BarInnerMargin.Top, BarInnerMargin.Right, BarInnerMargin.Bottom);
            }
        }
        /// <summary> バー内部の余白 </summary> 
        [XmlIgnore]
        public double BarInnerMargin_Top
        {
            get { return this.BarInnerMargin.Top; }
            set
            {
                this.BarInnerMargin = new Thickness(BarInnerMargin.Left, value, BarInnerMargin.Right, BarInnerMargin.Bottom);
            }
        }
        /// <summary> バー内部の余白 </summary> 
        [XmlIgnore]
        public double BarInnerMargin_Right
        {
            get { return this.BarInnerMargin.Right; }
            set
            {
                this.BarInnerMargin = new Thickness(BarInnerMargin.Left, BarInnerMargin.Top, value, BarInnerMargin.Bottom);
            }
        }
        /// <summary> バー内部の余白 </summary> 
        [XmlIgnore]
        public double BarInnerMargin_Bottom
        {
            get { return this.BarInnerMargin.Bottom; }
            set
            {
                this.BarInnerMargin = new Thickness(BarInnerMargin.Left, BarInnerMargin.Top, BarInnerMargin.Right, value);
            }
        }

        /// <summary> バーの丸さ </summary> 
        [XmlIgnore]
        public double CornerRadius_TopLeft
        {
            get { return this.CornerRadius.TopLeft; }
            set
            {
                this.CornerRadius = new CornerRadius(value, this.CornerRadius.TopRight, this.CornerRadius.BottomRight, this.CornerRadius.BottomLeft);
            }
        }
        /// <summary> バーの丸さ </summary> 
        [XmlIgnore]
        public double CornerRadius_TopRight
        {
            get { return this.CornerRadius.TopRight; }
            set
            {
                this.CornerRadius = new CornerRadius(this.CornerRadius.TopLeft, value, this.CornerRadius.BottomRight, this.CornerRadius.BottomLeft);
            }
        }
        /// <summary> バーの丸さ </summary> 
        [XmlIgnore]
        public double CornerRadius_BottomRight
        {
            get { return this.CornerRadius.BottomRight; }
            set
            {
                this.CornerRadius = new CornerRadius(this.CornerRadius.TopLeft, this.CornerRadius.TopRight, value, this.CornerRadius.BottomLeft);
            }
        }
        /// <summary> バーの丸さ </summary> 
        [XmlIgnore]
        public double CornerRadius_BottomLeft
        {
            get { return this.CornerRadius.BottomLeft; }
            set
            {
                this.CornerRadius = new CornerRadius(this.CornerRadius.TopLeft, this.CornerRadius.TopRight, this.CornerRadius.BottomRight, value);
            }
        }

        /// <summary> バー枠線の太さ </summary> 
        [XmlIgnore]
        public double BorderThickness_Left
        {
            get { return this.BorderThickness.Left; }
            set
            {
                this.BorderThickness = new Thickness(value, BorderThickness.Top, BorderThickness.Right, BorderThickness.Bottom);
            }
        }
        /// <summary> バー枠線の太さ </summary> 
        [XmlIgnore]
        public double BorderThickness_Top
        {
            get { return this.BorderThickness.Top; }
            set
            {
                this.BorderThickness = new Thickness(BorderThickness.Left, value, BorderThickness.Right, BorderThickness.Bottom);
            }
        }
        /// <summary> バー枠線の太さ </summary> 
        [XmlIgnore]
        public double BorderThickness_Right
        {
            get { return this.BorderThickness.Right; }
            set
            {
                this.BorderThickness = new Thickness(BorderThickness.Left, BorderThickness.Top, value, BorderThickness.Bottom);
            }
        }
        /// <summary> バー枠線の太さ </summary> 
        [XmlIgnore]
        public double BorderThickness_Bottom
        {
            get { return this.BorderThickness.Bottom; }
            set
            {
                this.BorderThickness = new Thickness(BorderThickness.Left, BorderThickness.Top, BorderThickness.Right, value);
            }
        }

        #endregion

        #region #- [Property] Thickness.BarInnerMargin - ＜バー内部の余白＞ -----
        /// <summary> バー内部の余白 </summary>
        private Thickness _BarInnerMargin;
        /// <summary> バー内部の余白 </summary>    
        public Thickness BarInnerMargin
        {
            get { return _BarInnerMargin; }
            set 
            {
                this.SetProperty(ref this._BarInnerMargin, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Thickness.CornerRadius - ＜バーの丸さ＞ -----
        /// <summary> バーの丸さ </summary>
        private CornerRadius _CornerRadius;
        /// <summary> バーの丸さ </summary>    
        public CornerRadius CornerRadius
        {
            get { return _CornerRadius; }
            set 
            {
                this.SetProperty(ref this._CornerRadius, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Thickness.BorderThickness - ＜バー枠線の太さ＞ -----
        /// <summary> バー枠線の太さ </summary>
        private Thickness _BorderThickness;
        /// <summary> バー枠線の太さ </summary>    
        public Thickness BorderThickness
        {
            get { return _BorderThickness; }
            set
            {
                this.SetProperty(ref this._BorderThickness, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.BorderColor - ＜線の色＞ -----
        /// <summary> 線の色 </summary>
        private Color _BorderColor;
        /// <summary> 線の色 </summary>    
        public Color BorderColor
        {
            get { return _BorderColor; }
            set 
            {
                this.SetProperty(ref this._BorderColor, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.BackgroundColor - ＜バー背景色＞ -----
        /// <summary> バー背景色 </summary>
        private Color _BackgroundColor;
        /// <summary> バー背景色 </summary>
        public Color BackgroundColor
        {
            get { return this._BackgroundColor; }
            set
            {
                this.SetProperty(ref this._BackgroundColor, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.BarColor1_Base - ＜バーカラー１.ベース＞ -----
        /// <summary> バーカラー１.ベース </summary>
        private Color _BarColor1_Base;
        /// <summary> バーカラー１.ベース </summary>    
        public Color BarColor1_Base
        {
            get { return _BarColor1_Base; }
            set 
            {
                this.SetProperty(ref this._BarColor1_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.BarColor2_Base - ＜バーカラー２.ベース＞ -----
        /// <summary> バーカラー２.ベース </summary>
        private Color _BarColor2_Base;
        /// <summary> バーカラー２.ベース </summary>    
        public Color BarColor2_Base
        {
            get { return _BarColor2_Base; }
            set 
            {
                this.SetProperty(ref this._BarColor2_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.BarColor3_Base - ＜バーカラー３.ベース＞ -----
        /// <summary> バーカラー３.ベース </summary>
        private Color _BarColor3_Base;
        /// <summary> バーカラー３.ベース </summary>    
        public Color BarColor3_Base
        {
            get { return _BarColor3_Base; }
            set 
            {
                this.SetProperty(ref this._BarColor3_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] BarHorizontalAlignment.BarHorizontalAlignment - ＜バー水平方向＞ -----
        /// <summary> バー水平方向 </summary>
        private HorizontalAlignment _BarHorizontalAlignment;
        /// <summary> バー水平方向 </summary>    
        public HorizontalAlignment BarHorizontalAlignment
        {
            get { return _BarHorizontalAlignment; }
            set
            {
                this.SetProperty(ref this._BarHorizontalAlignment, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] TextHorizontalAlignment.TextHorizontalAlignment - ＜テキスト水平方向＞ -----
        /// <summary> テキスト水平方向 </summary>
        private HorizontalAlignment _TextHorizontalAlignment;
        /// <summary> テキスト水平方向 </summary>    
        public HorizontalAlignment TextHorizontalAlignment
        {
            get { return _TextHorizontalAlignment; }
            set
            {
                this.SetProperty(ref this._TextHorizontalAlignment, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] TextVerticalAlignment.TextVerticalAlignment - ＜垂直方向＞ -----
        /// <summary> テキスト垂直方向 </summary>
        private VerticalAlignment _TextVerticalAlignment;
        /// <summary> テキスト垂直方向 </summary>    
        public VerticalAlignment TextVerticalAlignment
        {
            get { return _TextVerticalAlignment; }
            set
            {
                this.SetProperty(ref this._TextVerticalAlignment, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] DoubleVisibilityStyle.DoubleVisibilityStyle - ＜小数点表示スタイル＞ -----
        /// <summary> 小数点表示スタイル </summary>
        private DoubleVisibilityStyle _DoubleVisibilityStyle;
        /// <summary> 小数点表示スタイル </summary>    
        public DoubleVisibilityStyle DoubleVisibilityStyle
        {
            get { return _DoubleVisibilityStyle; }
            set
            {
                this.SetProperty(ref this._DoubleVisibilityStyle, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] double.BarActiveTime - ＜バーが動き出す時間＞ -----
        /// <summary> バーが動き出す時間 </summary>
        private double _BarActiveTime;
        /// <summary> バーが動き出す時間 </summary>    
        public double BarActiveTime
        {
            get { return _BarActiveTime; }
            set
            {
                this.SetProperty(ref this._BarActiveTime, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        
        #region #- [Property] double.GradientStop1StartTime - ＜Color1~2へのグラデーション開始時間＞ -----
        /// <summary> Color1~2へのグラデーション開始時間 </summary>
        private double _GradientStop1StartTime;
        /// <summary> Color1~2へのグラデーション開始時間 </summary>    
        public double GradientStop1StartTime
        {
            get { return _GradientStop1StartTime; }
            set
            {
                this.SetProperty(ref this._GradientStop1StartTime, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.GradientStop1EndTime - ＜Color1~2へのグラデーション終了時間＞ -----
        /// <summary> Color1~2へのグラデーション終了時間 </summary>
        private double _GradientStop1EndTime;
        /// <summary> Color1~2へのグラデーション終了時間 </summary>    
        public double GradientStop1EndTime
        {
            get { return _GradientStop1EndTime; }
            set
            {
                this.SetProperty(ref this._GradientStop1EndTime, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] double.GradientStop2StartTime - ＜Color2~3へのグラデーション開始時間＞ -----
        /// <summary> Color2~3へのグラデーション開始時間 </summary>
        private double _GradientStop2StartTime;
        /// <summary> Color2~3へのグラデーション開始時間 </summary>    
        public double GradientStop2StartTime
        {
            get { return _GradientStop2StartTime; }
            set
            {
                this.SetProperty(ref this._GradientStop2StartTime, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] double.GradientStop2EndTime - ＜Color2~3へのグラデーション終了時間＞ -----
        /// <summary> Color2~3へのグラデーション終了時間 </summary>
        private double _GradientStop2EndTime;
        /// <summary> Color2~3へのグラデーション終了時間 </summary>    
        public double GradientStop2EndTime
        {
            get { return _GradientStop2EndTime; }
            set
            {
                this.SetProperty(ref this._GradientStop2EndTime, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        /// <summary> バー形状コレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<BarFormType> BarFormTypeCollection { get; private set; }

        /// <summary> バー水平方向コレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<HorizontalAlignment> BarHorizontalAlignmentCollection { get; private set; }
        /// <summary> テキスト水平方向コレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<HorizontalAlignment> TextHorizontalAlignmentCollection { get; private set; }
        /// <summary> テキスト垂直方向コレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<VerticalAlignment> TextVerticalAlignmentCollection { get; private set; }
        /// <summary> 小数点表示スタイルコレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<DoubleVisibilityStyle> DoubleStyleCollection { get; private set; }

        /// <summary> 変更前カラー情報
        /// </summary>
        [XmlIgnore]
        public Color BeforeColor { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ各種バー設定データ
        /// </summary>
        public OverlayBarSettingsData()
            : base()
        {
            this.initData();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.BarFormType = BarFormType.SimpleType;

            this.BarMargin = new Thickness(1, 5, 35, 5);
            this.BarInnerMargin = new Thickness(1, 1, 1, 1);
            this.CornerRadius = new CornerRadius(0, 0, 0, 0);
            this.BorderThickness = new Thickness(1, 1, 1, 1);

            this.BarFormTypeCollection = new ObservableCollection<BarFormType>();
            this.BarHorizontalAlignmentCollection = new ObservableCollection<HorizontalAlignment>();
            this.TextHorizontalAlignmentCollection = new ObservableCollection<HorizontalAlignment>();
            this.TextVerticalAlignmentCollection = new ObservableCollection<VerticalAlignment>();
            this.DoubleStyleCollection = new ObservableCollection<DoubleVisibilityStyle>();

            foreach (BarFormType value in Enum.GetValues(typeof(BarFormType)))
            {
                this.BarFormTypeCollection.Add(value);
            }

            foreach (HorizontalAlignment value in Enum.GetValues(typeof(HorizontalAlignment)))
            {
                this.BarHorizontalAlignmentCollection.Add(value);
                this.TextHorizontalAlignmentCollection.Add(value);
            }

            foreach (VerticalAlignment value in Enum.GetValues(typeof(VerticalAlignment)))
            {
                this.TextVerticalAlignmentCollection.Add(value);
            }

            foreach (DoubleVisibilityStyle value in Enum.GetValues(typeof(DoubleVisibilityStyle)))
            {
                this.DoubleStyleCollection.Add(value);
            }

            this.DoubleVisibilityStyle = Core.DoubleVisibilityStyle.N0;
            this.TextHorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            this.TextVerticalAlignment = System.Windows.VerticalAlignment.Center;

            this.BarActiveTime = 0d;
            this.GradientStop1StartTime = 0d;
            this.GradientStop1EndTime = 0d;
            this.GradientStop2StartTime = 0d;
            this.GradientStop2EndTime = 0d;


            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アクティブバー型のデフォルトセットアップを実行します。
        /// </summary>
        public void DefaultSetup_ActiveBar()
        {
            this.BorderColor = Color.FromArgb(0xAA, 0x88, 0x88, 0x88);
            this.BackgroundColor = Color.FromArgb(0x00, 0x88, 0x88, 0x88);
            this.BarColor1_Base = Color.FromArgb(0xAA, 0x8E, 0xEF, 0x21);
            this.BarColor2_Base = Color.FromArgb(0xAA, 0xE9, 0xAF, 0x10);
            this.BarColor3_Base = Color.FromArgb(0xAA, 0xFF, 0x00, 0x11);

            this.BarHorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            this.BarActiveTime = 12d;
            this.GradientStop1StartTime = 9d;
            this.GradientStop1EndTime = 7d;
            this.GradientStop2StartTime = 5d;
            this.GradientStop2EndTime = 3d;
        }

        /// <summary> キャストバー型のデフォルトセットアップを実行します。
        /// </summary>
        public void DefaultSetup_CastBar()
        {
            this.BorderColor = Color.FromArgb(0xAA, 0x88, 0x88, 0x88);
            this.BackgroundColor = Color.FromArgb(0x00, 0x88, 0x88, 0x88);
            this.BarColor1_Base = Color.FromArgb(0xAA, 0xFF, 0x00, 0x11);
            this.BarColor2_Base = Color.FromArgb(0xAA, 0xEA, 0x0E, 0x17);
            this.BarColor3_Base = Color.FromArgb(0xAA, 0xEA, 0x3A, 0xEA);

            this.BarHorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.BarActiveTime = 3d;
            this.GradientStop1StartTime = 3d;
            this.GradientStop1EndTime = 2d;
            this.GradientStop2StartTime = 2d;
            this.GradientStop2EndTime = 1d;
        }

        /// <summary> 変更前カラー情報を取得して設定します。
        /// </summary>
        public void SetBeforeColor()
        {
            this.BeforeColor = this.getEditTargetColor();
        }

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 変更ターゲットとなるカラーに値を設定します。
        /// </summary>
        /// <param name="pColor"> 変更カラー </param>
        private void setEditTargetColor(Color pColor)
        {
            switch (this.ColorEditTarget)
            {
                case ColorEditTarget.Non:
                    break;

                case ColorEditTarget.BarBackgroung_Base:
                    this.BackgroundColor = pColor;
                    break;
                case ColorEditTarget.BarBorder_Base:
                    this.BorderColor = pColor;
                    break;
                case ColorEditTarget.BarColor1_Base:
                    this.BarColor1_Base = pColor;
                    break;
                case ColorEditTarget.BarColor2_Base:
                    this.BarColor2_Base = pColor;
                    break;
                case ColorEditTarget.BarColor3_Base:
                    this.BarColor3_Base = pColor;
                    break;
            }
        }


        /// <summary> 変更ターゲットとなるカラーから値を取得します。
        /// </summary>
        /// <param name="pColor"> 変更カラー </param>
        private Color getEditTargetColor()
        {
            switch (this.ColorEditTarget)
            {
                case ColorEditTarget.BarBackgroung_Base:
                    return this.BackgroundColor;
                case ColorEditTarget.BarBorder_Base:
                    return this.BorderColor;

                case ColorEditTarget.BarColor1_Base:
                    return this.BarColor1_Base;
                case ColorEditTarget.BarColor2_Base:
                    return this.BarColor2_Base;
                case ColorEditTarget.BarColor3_Base:
                    return this.BarColor3_Base;

                default:
                    return Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
            }

        }

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
