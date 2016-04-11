﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／アプリケーションデータ
    /// </summary>
    public class ApplicationData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- File Name ---

        /// <summary> タイムライン設定データの名前
        /// </summary>
        public string TimelineSettingsFileName { get; set; }

        /// <summary> オーバーレイデータである事を示す名前
        /// </summary>
        public string OverlayDataPartName { get; set; }

        #endregion 

        #region --- Path ---

        /// <summary> タイムラインアプリケーションのRoamingパス
        /// </summary>
        public string RoamingDirectoryPath { get; set; }

        /// <summary> オーバーレイデータのディレクトリパス
        /// </summary>
        public string OverlayDataDirectoryPath { get; set; }

        /// <summary> オーバーレイデータのファイルパス一覧
        /// </summary>
        public List<string> OverlayDataFilePathList { get; set; }

        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／アプリケーションデータ／コンストラクタ
        /// </summary>
        public ApplicationData()
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
            this.OverlayDataFilePathList = new List<string>();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

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

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.RoamingDirectoryPath = string.Empty;
            this.OverlayDataDirectoryPath = string.Empty;
            this.OverlayDataFilePathList.Clear();

            return true;
        }
    }
}