using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OpenCTT
{
    public partial class SoftConsCoursesBaseSettingsForm : Form
    {
        private Hashtable _courseLessonBlocks;
        public SoftConsCoursesBaseSettingsForm()
        {
            InitializeComponent();
        }

        private void SoftConsCoursesBaseSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = AppForm.getAppForm()._scBaseCoursesMenuItem.Text;

            _courseLessonBlocks = SCBaseSettings.COURSE_LESSON_BLOCKS;

            int[] lessonB = (int[])_courseLessonBlocks["2"];
            _21TextBox.Text = ((int)lessonB[0]).ToString();
            _22TextBox.Text = ((int)lessonB[1]).ToString();
            _23TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["3"];
            _31TextBox.Text = ((int)lessonB[0]).ToString();
            _32TextBox.Text = ((int)lessonB[1]).ToString();
            _33TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["4"];
            _41TextBox.Text = ((int)lessonB[0]).ToString();
            _42TextBox.Text = ((int)lessonB[1]).ToString();
            _43TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["5"];
            _51TextBox.Text = ((int)lessonB[0]).ToString();
            _52TextBox.Text = ((int)lessonB[1]).ToString();
            _53TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["6"];
            _61TextBox.Text = ((int)lessonB[0]).ToString();
            _62TextBox.Text = ((int)lessonB[1]).ToString();
            _63TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["7"];
            _71TextBox.Text = ((int)lessonB[0]).ToString();
            _72TextBox.Text = ((int)lessonB[1]).ToString();
            _73TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["8"];
            _81TextBox.Text = ((int)lessonB[0]).ToString();
            _82TextBox.Text = ((int)lessonB[1]).ToString();
            _83TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["9"];
            _91TextBox.Text = ((int)lessonB[0]).ToString();
            _92TextBox.Text = ((int)lessonB[1]).ToString();
            _93TextBox.Text = ((int)lessonB[2]).ToString();

            lessonB = (int[])_courseLessonBlocks["default"];
            _101TextBox.Text = ((int)lessonB[0]).ToString();
            _102TextBox.Text = ((int)lessonB[1]).ToString();
            _103TextBox.Text = ((int)lessonB[2]).ToString();

            _okButton.Enabled = false;
        }


        private void allTextBoxs_TextChanged(object sender, EventArgs e)
        {
            if (isFormValuesOKAndChanged())
            {
                _okButton.Enabled = true;

            }
            else
            {

                _okButton.Enabled = false;
            }

        }

        private bool isFormValuesOKAndChanged()
        {
            try
            {
                int x21 = Int32.Parse(_21TextBox.Text);
                int x22 = Int32.Parse(_22TextBox.Text);
                int x23 = Int32.Parse(_23TextBox.Text);

                int x31 = Int32.Parse(_31TextBox.Text);
                int x32 = Int32.Parse(_32TextBox.Text);
                int x33 = Int32.Parse(_33TextBox.Text);

                int x41 = Int32.Parse(_41TextBox.Text);
                int x42 = Int32.Parse(_42TextBox.Text);
                int x43 = Int32.Parse(_43TextBox.Text);

                int x51 = Int32.Parse(_51TextBox.Text);
                int x52 = Int32.Parse(_52TextBox.Text);
                int x53 = Int32.Parse(_53TextBox.Text);

                int x61 = Int32.Parse(_61TextBox.Text);
                int x62 = Int32.Parse(_62TextBox.Text);
                int x63 = Int32.Parse(_63TextBox.Text);

                int x71 = Int32.Parse(_71TextBox.Text);
                int x72 = Int32.Parse(_72TextBox.Text);
                int x73 = Int32.Parse(_73TextBox.Text);

                int x81 = Int32.Parse(_81TextBox.Text);
                int x82 = Int32.Parse(_82TextBox.Text);
                int x83 = Int32.Parse(_83TextBox.Text);

                int x91 = Int32.Parse(_91TextBox.Text);
                int x92 = Int32.Parse(_92TextBox.Text);
                int x93 = Int32.Parse(_93TextBox.Text);

                int x101 = Int32.Parse(_101TextBox.Text);
                int x102 = Int32.Parse(_102TextBox.Text);
                int x103 = Int32.Parse(_103TextBox.Text);

                if (x21 > 0 && x22 > 0 && x23 > 0 && x31 > 0 && x32 > 0 && x33 > 0 && x41 > 0 && x42 > 0 && x43 > 0 && x51 > 0 && x52 > 0 && x53 > 0 && x61 > 0 && x62 > 0 && x63 > 0 && x71 > 0 && x72 > 0 && x73 > 0 && x81 > 0 && x82 > 0 && x83 > 0 && x91 > 0 && x92 > 0 && x93 > 0 && x101 > 0 && x102 > 0 && x103 > 0)
                {
                    int[] lessonB = (int[])_courseLessonBlocks["2"];

                    if (x21 != (int)lessonB[0] || x22 != (int)lessonB[1] || x23 != (int)lessonB[2])
                    {
                        return true;
                    }
                    else
                    {
                        lessonB = (int[])_courseLessonBlocks["3"];

                        if (x31 != (int)lessonB[0] || x32 != (int)lessonB[1] || x33 != (int)lessonB[2])
                        {
                            return true;
                        }
                        else
                        {
                            lessonB = (int[])_courseLessonBlocks["4"];

                            if (x41 != (int)lessonB[0] || x42 != (int)lessonB[1] || x43 != (int)lessonB[2])
                            {
                                return true;
                            }
                            else
                            {
                                lessonB = (int[])_courseLessonBlocks["5"];

                                if (x51 != (int)lessonB[0] || x52 != (int)lessonB[1] || x53 != (int)lessonB[2])
                                {
                                    return true;
                                }
                                else
                                {
                                    lessonB = (int[])_courseLessonBlocks["6"];

                                    if (x61 != (int)lessonB[0] || x62 != (int)lessonB[1] || x63 != (int)lessonB[2])
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        lessonB = (int[])_courseLessonBlocks["7"];

                                        if (x71 != (int)lessonB[0] || x72 != (int)lessonB[1] || x73 != (int)lessonB[2])
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            lessonB = (int[])_courseLessonBlocks["8"];

                                            if (x81 != (int)lessonB[0] || x82 != (int)lessonB[1] || x83 != (int)lessonB[2])
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                lessonB = (int[])_courseLessonBlocks["9"];

                                                if (x91 != (int)lessonB[0] || x92 != (int)lessonB[1] || x93 != (int)lessonB[2])
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    lessonB = (int[])_courseLessonBlocks["default"];

                                                    if (x101 != (int)lessonB[0] || x102 != (int)lessonB[1] || x103 != (int)lessonB[2])
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }                            
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }

            return true;

        }


        public Hashtable NewCoursesLessonsBlocksHT
        {
            get
            {
                int x21 = Int32.Parse(_21TextBox.Text);
                int x22 = Int32.Parse(_22TextBox.Text);
                int x23 = Int32.Parse(_23TextBox.Text);

                int x31 = Int32.Parse(_31TextBox.Text);
                int x32 = Int32.Parse(_32TextBox.Text);
                int x33 = Int32.Parse(_33TextBox.Text);

                int x41 = Int32.Parse(_41TextBox.Text);
                int x42 = Int32.Parse(_42TextBox.Text);
                int x43 = Int32.Parse(_43TextBox.Text);

                int x51 = Int32.Parse(_51TextBox.Text);
                int x52 = Int32.Parse(_52TextBox.Text);
                int x53 = Int32.Parse(_53TextBox.Text);

                int x61 = Int32.Parse(_61TextBox.Text);
                int x62 = Int32.Parse(_62TextBox.Text);
                int x63 = Int32.Parse(_63TextBox.Text);

                int x71 = Int32.Parse(_71TextBox.Text);
                int x72 = Int32.Parse(_72TextBox.Text);
                int x73 = Int32.Parse(_73TextBox.Text);

                int x81 = Int32.Parse(_81TextBox.Text);
                int x82 = Int32.Parse(_82TextBox.Text);
                int x83 = Int32.Parse(_83TextBox.Text);

                int x91 = Int32.Parse(_91TextBox.Text);
                int x92 = Int32.Parse(_92TextBox.Text);
                int x93 = Int32.Parse(_93TextBox.Text);

                int x101 = Int32.Parse(_101TextBox.Text);
                int x102 = Int32.Parse(_102TextBox.Text);
                int x103 = Int32.Parse(_103TextBox.Text);

                Hashtable ht = new Hashtable();

                int[] lesson2 = new int[3];
                lesson2[0] = x21;//minBlockSize
                lesson2[1] = x22;//minNumOfBlocks
                lesson2[2] = x23;//maxNumOfBlocks
                ht.Add("2", lesson2);

                int[] lesson3 = new int[3];
                lesson3[0] = x31;
                lesson3[1] = x32;
                lesson3[2] = x33;
                ht.Add("3", lesson3);

                int[] lesson4 = new int[3];
                lesson4[0] = x41;
                lesson4[1] = x42;
                lesson4[2] = x43;
                ht.Add("4", lesson4);

                int[] lesson5 = new int[3];
                lesson5[0] = x51;
                lesson5[1] = x52;
                lesson5[2] = x53;
                ht.Add("5", lesson5);

                int[] lesson6 = new int[3];
                lesson6[0] = x61;
                lesson6[1] = x62;
                lesson6[2] = x63;
                ht.Add("6", lesson6);

                int[] lesson7 = new int[3];
                lesson7[0] = x71;
                lesson7[1] = x72;
                lesson7[2] = x73;
                ht.Add("7", lesson7);

                int[] lesson8 = new int[3];
                lesson8[0] = x81;
                lesson8[1] = x82;
                lesson8[2] = x83;
                ht.Add("8", lesson8);

                int[] lesson9 = new int[3];
                lesson9[0] = x91;
                lesson9[1] = x92;
                lesson9[2] = x93;
                ht.Add("9", lesson9);

                int[] lesson_default = new int[3];
                lesson_default[0] = x101;
                lesson_default[1] = x102;
                lesson_default[2] = x103;
                ht.Add("default", lesson_default);

                return ht;
            }
        }
    }
}