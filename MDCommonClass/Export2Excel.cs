using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; using MDSolutionEntities;
using Janus.Windows.GridEX;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using MDSolution;

namespace MDSolution
{
    public class Export2Excel
    {
        static public void Convert(System.Data.DataTable dt, long SoCot,string TieuDe)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.Length > 0)
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                  
                    try
                    {
                        // Create the object of l_objExcel application .  
                        xlApp = new Microsoft.Office.Interop.Excel.Application();

                        // Create workbook .  
                        xlWorkBook = xlApp.Workbooks.Add(Type.Missing);

                        // Get active sheet from workbook  
                        xlWorkSheet = xlWorkBook.ActiveSheet;
                        xlWorkSheet.Name = TieuDe;

                        // For showing alert message of overwritting of existing file .  
                        xlApp.DisplayAlerts = false;

                        // Fill the l_objExcel from p_dtData data  .  
                        for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < SoCot; colIndex++)
                            {
                                // Create the columns in the Excel .  
                                if (rowIndex == 0)
                                {
                                    // Write column name into Excel cell .  
                                    xlWorkSheet.Cells[rowIndex + 1, colIndex + 1] = dt.Columns[colIndex].Caption;
                                    xlWorkSheet.Cells.Font.Color = System.Drawing.Color.Black;

                                }

                                // Write row value into Excel cell .  
                                xlWorkSheet.Cells[rowIndex + 2, colIndex + 1] = dt.Rows[rowIndex][colIndex];

                                // Formating Excel cell on the bases of column type datatable  

                                if (dt.Columns[colIndex].DataType == Type.GetType("System.Decimal"))
                                {
                                    // Currency Format .  
                                    //l_objExcel.Range[l_objExcel.Cells[rowIndex + 2, colIndex + 1], l_objExcel.Cells[rowIndex + 2, colIndex + 1]].NumberFormat
                                    //    = "$#,##0.00_);[Red]($#,##0.00)";
                                }
                                else if (dt.Columns[colIndex].DataType == Type.GetType("System.DateTime"))
                                {
                                    //datetime format  
                                    xlApp.Range[xlApp.Cells[rowIndex + 2, colIndex + 1], xlApp.Cells[rowIndex + 2, colIndex + 1]].NumberFormat
                                        = "yyyy-MM-dd HH:mm:ss";

                                }
                                else if (dt.Columns[colIndex].DataType == Type.GetType("System.String"))
                                {
                                    // Set Font  
                                    //l_objExcel.Range[l_objExcel.Cells[rowIndex + 2, colIndex + 1], l_objExcel.Cells[rowIndex + 2, colIndex + 1]].Font.Bold = true;
                                    //l_objExcel.Range[l_objExcel.Cells[rowIndex + 2, colIndex + 1], l_objExcel.Cells[rowIndex + 2, colIndex + 1]].Font.Name = "Arial Narrow";
                                    //l_objExcel.Range[l_objExcel.Cells[rowIndex + 2, colIndex + 1], l_objExcel.Cells[rowIndex + 2, colIndex + 1]].Font.Size = "20";

                                }
                                else if (dt.Columns[colIndex].DataType == Type.GetType("System.Single"))
                                {
                                    // Set percentage  .  
                                   // xlApp.Range[xlApp.Cells[rowIndex + 2, colIndex + 1], xlApp.Cells[rowIndex + 2, colIndex + 1]].NumberFormat = "0.00%";
                                }

                            }
                        }
                        //l_objExcelSheet.Range[l_objExcelSheet.Cells[1, 1], l_objExcelSheet.Cells[1, p_dtData.Columns.Count]].Interior.Color =
                        // System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                       
                        xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, SoCot]].Font.Bold = true;
                        xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, SoCot]].Font.Size = 15;  
                        xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dt.Rows.Count, SoCot]].EntireColumn.AutoFit();  
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                    MessageBox.Show("Đã export dữ liệu ra định dạng file Excel thành công", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    }
                     catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    finally
                    {
                        xlWorkSheet = null;
                        xlWorkBook = null;
                    }  
                }
                
            }


        }

        static  public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        static public Excel.Application TryGetExistingExcelApplication()
        {
            try
            {
                object o =  System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                return (Excel.Application)o;
            }
            catch 
            {
                // Probably there is no existing Excel instance running, return null
                return null;
            }
        }
    }
}
