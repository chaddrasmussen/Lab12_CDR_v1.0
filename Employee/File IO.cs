// File Prologue
// Mason McEwen
// Lab12
// created 4/28/14
// CS 3260 section 001
//-----------------------------------------------
// I worked on this with Chad Rasmussen
// I declare that the following source code was written by me, or provided
// by the instructor for this project. I understand that copying 
// source code from any other source constitutes cheating, and that I will
// receive a zero grade on this project if I am found in violation of
// this policy
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
namespace Employee
{
    static class File_IO
    {
        private static string filename = "employee.bin";
        static BinaryFormatter bf = new BinaryFormatter();
        static OpenFileDialog open = new OpenFileDialog();
        static Stream stream = new FileStream(filename, FileMode.OpenOrCreate);
        /// <summary>
        /// deserializes from file
        /// </summary>
        /// <param name="sd"></param>
        public static void Read(ref SortedDictionary<uint, Employee> sd)
        {
            try
            {
                sd = (SortedDictionary<uint, Employee>)bf.Deserialize(stream);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            stream.Close();
        }

        public static void ReadFromFile(ref SortedDictionary<uint,Employee> sd)
        {
            open.Filter = "bin files (*.bin)|*.bin";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = open.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            sd = (SortedDictionary<uint, Employee>)bf.Deserialize(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                stream.Close();
            }

        }
        /// <summary>
        /// serializes to file
        /// </summary>
        /// <param name="sd"></param>
        public static void Write(SortedDictionary<uint, Employee> sd)
        {
            stream = new FileStream(filename, FileMode.Create);
            try
            {
                bf.Serialize(stream, sd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                stream.Flush();
                stream.Close();
            }
        }
    }
}