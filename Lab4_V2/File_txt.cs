﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Lab_4 {
    class Memento {
        public Dictionary<string, string> Content { get; set; }
        public List<string> FileName { get; set; }
    }

    public class Caretaker {
        private object memento;
        public void SaveState(IOriginator originator) {
            originator.SetMemento(memento);
        }

        public void RestoreState(IOriginator originator) {
            memento = originator.GetMemento();
        }
    }

    [Serializable]
    class TextClass : IOriginator {
        public Dictionary<string, string> Content { get; set; }
        public List<string> FileName { get; set; }

        public TextClass() {
            Content = new Dictionary<string, string>();
            FileName = new List<string>();
        }
        public TextClass(string Content, string FileName) {
            this.Content.Add(FileName, Content);
            this.FileName.Add(FileName);
        }

        public void BinarySerialization(FileStream fs) {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void BinaryDeserialization(FileStream fs) {
            BinaryFormatter bf = new BinaryFormatter();
            TextClass deserialized = (TextClass)bf.Deserialize(fs);
            Content = deserialized.Content;
            FileName = deserialized.FileName;
            fs.Close();
        }

        public void XmlSerialization(FileStream fs) {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextClass));
            xmlserializer.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void XmlDeserialization(FileStream fs) {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextClass));
            TextClass deserialized = (TextClass)xmlserializer.Deserialize(fs);
            Content = deserialized.Content;
            FileName = deserialized.FileName;
            fs.Close();
        }

        object IOriginator.GetMemento() {
            return new Memento { Content = this.Content, FileName = this.FileName };
        }

        void IOriginator.SetMemento(object memento) {
            if (memento is Memento) {
                var mem = memento as Memento;
                Content = mem.Content;
                FileName = mem.FileName;
            }
        }
    }
}