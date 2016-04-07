﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace FairyZeta.Framework.Process
{
    /// <summary> フレームワーク／XMLシリアライズプロセス
    /// </summary>
    public class XmlSerializerProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フレームワーク／XMLシリアライズプロセス／コンストラクタ
        /// </summary>
        public XmlSerializerProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトをXMLにシリアライズします。 
        /// </summary>
        /// <param name="path"> string : 書込XMLのファイルパス </param>
        /// <param name="obj"> object : 保存するオブジェクト </param>
        /// <param name="nonCatch"> シリアライズエラーを 無視する場合は true </param>
        public void XmlSave(string path, object obj, bool nonCatch)
        {
            if (nonCatch)
            {
                this.xmlSave_NonException(path, obj);
            }
            else
            {
                this.xmlSave(path, obj);
            }
        }

        /// <summary> XMLファイルを逆シリアライズします。 
        /// </summary>
        /// <param name="path"> 読込XMLのファイルパス </param>
        /// <param name="type"> 復元するオブジェクトの型 </param>
        /// <param name="nonCatch"> シリアライズエラーを 無視する場合は true </param>
        /// <returns> 復元オブジェクト </returns>
        public object XmlLoad(string path, Type type, bool nonCatch)
        {
            if (nonCatch)
            {
                return this.xmlLoad_NonException(path, type);
            }
            else
            {
                return this.xmlLoad(path, type);
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> シリアライズエラーを無視して、オブジェクトをXMLにシリアライズします。 
        /// </summary>
        /// <param name="path"> string : 書込XMLのファイルパス </param>
        /// <param name="obj"> object : 保存するオブジェクト </param>
        private void xmlSave_NonException(string path, object obj)
        {
            try
            {
                this.xmlSave(path, obj);
            }
            finally
            {
            }

            return;
        }

        /// <summary> オブジェクトをXMLにシリアライズします。 
        /// </summary>
        /// <param name="path"> string : 書込XMLのファイルパス </param>
        /// <param name="obj"> object : 保存するオブジェクト </param>
        private void xmlSave(string path, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            serializer.Serialize(fs, obj);
            fs.Close();
        }

        /// <summary> シリアライズエラーを無視して、XMLファイルを逆シリアライズします。 
        /// </summary>
        /// <param name="path"> 読込XMLのファイルパス </param>
        /// <param name="type"> 復元するオブジェクトの型 </param>
        /// <returns> 復元オブジェクト </returns>
        private object xmlLoad_NonException(string path, Type type)
        {
            object obj;

            try
            {
                obj = this.xmlLoad(path, type);
            }
            finally
            {
            }
            return obj;
        }

        /// <summary> XMLファイルを逆シリアライズします。 
        /// </summary>
        /// <param name="path"> 読込XMLのファイルパス </param>
        /// <param name="type"> 復元するオブジェクトの型 </param>
        /// <returns> 復元オブジェクト </returns>
        private object xmlLoad(string path, Type type)
        {
            if (File.Exists(path))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                FileStream fs = new FileStream(path, FileMode.Open);
                object result = serializer.Deserialize(fs);
                fs.Close();

                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
