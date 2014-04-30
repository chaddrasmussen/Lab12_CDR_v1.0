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
using System.Collections;
using System.Windows.Forms;


namespace Employee 
{
    /// <summary>
    /// dynamic array class with initial size of four
    /// </summary>
    sealed class DArray : object, IEnumerable
    {  
        private int aIndex;
        private int capacity;
        private int top;
        private Employee[] empArray;
        private Employee[] tempArray;

        /// <summary>
        /// static readonly instance to make a BusinessRules.Instance class
        /// </summary>
        private static readonly DArray instance = new DArray();

        /// <summary>
        /// singular instance of the BusinessRules.Instance DArray class
        /// </summary>
        public static DArray Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// initializes a new employee array
        /// </summary>
        private DArray()
        {
            top = 0;
            aIndex = 0;
            capacity = 1;
            empArray = new Employee[capacity];
        }

        /// <summary>
        /// indexer for empArray
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Employee this[int index]
        {          
            get
            {
                if (index < top && top >= 0 && top <= capacity)
                    return empArray[index];
                else
                {
                    MessageBox.Show("Get -> Index out of bounds");
                    return default(Employee);
                }
            }
            set
            {
                if (index < top && top >= 0 && top < capacity)
                {
                    empArray[index] = value;
                }
                else if (index == top && top < capacity)
                {
                    empArray[index] = value;
                    top++;
                }
                else if (index == top || top >= capacity)
                {
                    Resize();
                    empArray[index] = value;
                    top++;
                    return;
                }
                else
                    MessageBox.Show("Set -> Index out of bounds");
            }
        }

        /// <summary>
        /// gets the enumerator for ienumerable interface
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            IEnumerator myIEnum = new MyEnum(empArray);
            return myIEnum;
        }

        /// <summary>
        /// resizes the array to twice the current capacity
        /// </summary>
        private void Resize()
        {
            capacity *= 2;
            tempArray = new Employee[capacity];
            empArray.CopyTo(tempArray, 0);
            empArray = tempArray;
            tempArray = null;
        }

        /// <summary>
        /// checks if array is filled, if yes then it resizes and adds object, if no then just adds object
        /// </summary>
        /// <param name="e"></param>
        public void AddValue(Employee e)
        {
            if (empArray.Length <= aIndex)
            {
                Resize();
                empArray[aIndex] = e;
                aIndex++;
            }
            else
            {
                empArray[aIndex] = e;
                aIndex++;
            }
        }

        /// <summary>
        /// gets the employee object stored at location i
        /// </summary>
        /// <param name="i"></param>
        public Employee GetValue(int i)
        {
            return empArray[i];
        }

    } // end DArray

    /// <summary>
    /// enumerator object with ienumerator interface
    /// </summary>
    class MyEnum : object, IEnumerator
    {
        private int top;
        private object current;
        private Employee[] enumArray;

        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="eArray"></param>
        public MyEnum(Employee[] eArray)
        {
            enumArray = eArray;
            current = 0;
            top = -1;
        }

        /// <summary>
        /// gets reference to next element
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (top >= -1 && top < enumArray.Length - 1)
            {
                top++;
                current = enumArray[top];
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// returns current object
        /// </summary>
        public object Current
        {
            get { return current; }
        }

        /// <summary>
        /// resets the enumerator
        /// </summary>
        public void Reset()
        {
            top = -1;
            current = null;
        }
    } // end MyEnum
    
}
