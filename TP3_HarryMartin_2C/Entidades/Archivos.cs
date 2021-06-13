﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public static class Archivos
    {
        #region Binaries
        public static bool GuardarBin<T>(string path, T item)
        {
            bool ret = false;
            Stream fs = new FileStream(path, FileMode.Create);
            if (fs != null)
            {
                BinaryFormatter ser = new BinaryFormatter();
                ser.Serialize(fs, item);
                fs.Close();
                ret = true;
            }
            else
            {
                throw new FileNotFoundException("No se pudo crear el archivo BIN");
            }
            return ret;
        }
        public static T LeerBin<T>(string path)
        {
            T item = default;
            Stream fs = new FileStream(path, FileMode.Open);
            if (fs != null)
            {
                BinaryFormatter ser = new BinaryFormatter();
                item = (T)ser.Deserialize(fs);
                fs.Close();
            }
            else
            {
                throw new FileNotFoundException("No se pudo leer el archivo BIN");
            }
            return item;
        }

        #endregion

        #region Text
        public static bool GuardarTxt(string path, string data)
        {
            bool ret = false;
            StreamWriter writer = new StreamWriter(path);
            if (writer != null)
            {
                writer.WriteLine(data);
                writer.Close();
                ret = true;
            }
            else
            {
                throw new FileNotFoundException("No se pudo crear el archivo TXT");
            }
            return ret;
        }
        public static string LeerTxt(string path)
        {
            string ret = null;
            StreamReader reader = new StreamReader(path);
            if (reader != null)
            {
                ret = reader.ReadLine();
                reader.Close();
            }
            else
            {
                throw new FileNotFoundException("No se pudo leer el archivo TXT");
            }
            return ret;
        }
        #endregion

        #region XML
        public static bool GuardarXML<T>(string path, T item)
        {
            bool ret = false;
            XmlSerializer serializer;
            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
            if (writer!= null)
            {
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, item);
                writer.Close();
                ret = true;

            }
            else
            {
                throw new FileNotFoundException("No se pudo crear el archivo XML");
            }
            return ret;

        }
        public static T LeerXML<T>(string path)
        {
            T item = default;
            XmlTextReader reader = new XmlTextReader(path);
            XmlSerializer serializer;
            if (reader != null)
            {
                serializer = new XmlSerializer(typeof(T));
                item = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                throw new FileNotFoundException("No se pudo leer el archivo XML");
            }
            return item;
        }
        #endregion
    }
}
