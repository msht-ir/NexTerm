using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Math;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Application = System.Windows.Forms.Application;
namespace NexTerm
	{
	public partial class frmTermProgs
		{
		public int cmdLineStatus0 = 0;
		public frmTermProgs ()
			{
			InitializeComponent ();
			}
		//form load
		private void frmTermProgs_Load (object sender, EventArgs e)
			{
			Width = 1305;
			Height = 725;
			//reset (hide) popup menu in grid4
			Grid4PopupMenuItems (0);
			try
				{
				Text = User.Type + "  Connected to :  " + NxDb.Server2Connect;
				ComboBox1.DataSource = NxDb.DS.Tables ["tblDepartments"];
				ComboBox1.DisplayMember = "DEPT";
				ComboBox1.ValueMember = "ID";
				ComboBox1.SelectedValue = User.Id;
				GridWeek.Rows.Add ("ش");
				GridWeek.Rows.Add ("ی");
				GridWeek.Rows.Add ("د");
				GridWeek.Rows.Add ("س");
				GridWeek.Rows.Add ("چ");
				GridWeek.Rows.Add ("پ");
				GridTime.Rows.Add ("شنبه");
				GridTime.Rows.Add ("یکشنبه");
				GridTime.Rows.Add ("دوشنبه");
				GridTime.Rows.Add ("سه شنبه");
				GridTime.Rows.Add ("چهارشنبه");
				GridTime.Rows.Add ("پنجشنبه");
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			for (int i = 0; i <= 8; i++)
				{
				GridWeek.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
				GridTime.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
				}
			EnableMenu ();
			}
		private void EnableMenu ()
			{
			bool boolENBL = true;
			if (User.Type == "UserDeputy")
				boolENBL = true;
			else if (User.Type == "UserOfficer")
				boolENBL = false;

			try
				{
				switch (User.Type)
					{
					case "UserDeputy":
					case "UserOfficer":
							{
							Menu_Settings.Enabled = boolENBL;
							Menu_Courses.Enabled = boolENBL;
							Menu_Staff.Enabled = boolENBL;
							Menu_Tech.Enabled = boolENBL;
							Menu_ReProgram_ThisEnteryTerm.Enabled = boolENBL;
							Menu_ReProgram_ThisEnteryTerm_inclStaff.Enabled = boolENBL;
							Menu_ChangePass.Enabled = boolENBL;
							Menu_Classes.Enabled = boolENBL;
							Menu_Terms.Enabled = boolENBL;
							Menu_Delete_Entry_TermProg.Enabled = boolENBL;
							PopMenuGrid4.Enabled = boolENBL;
							MenuAddGroup.Enabled = boolENBL;
							MenuAddCourse.Enabled = boolENBL;
							MenuReplaceCourse.Enabled = boolENBL;
							MenuDelCourse.Enabled = boolENBL;
							break;
							}
					case "UserDepartment":
							{
							Menu_Settings.Enabled = false;
							if ((User.ACCs & 0x1) == 0x0)
								Menu_Courses.Enabled = false;
							else
								Menu_Courses.Enabled = true;
							if ((User.ACCs & 0x1) == 0x0)
								Menu_Staff.Enabled = false;
							else
								Menu_Staff.Enabled = true;
							if ((User.ACCs & 0x2) == 0x0)
								Menu_Tech.Enabled = false;
							else
								Menu_Tech.Enabled = true;
							if ((User.ACCs & 0x8) == 0x0)
								Menu_ReProgram_ThisEnteryTerm.Enabled = false;
							else
								Menu_ReProgram_ThisEnteryTerm.Enabled = true;
							if ((User.ACCs & 0x8) == 0x0)
								Menu_ReProgram_ThisEnteryTerm_inclStaff.Enabled = false;
							else
								Menu_ReProgram_ThisEnteryTerm_inclStaff.Enabled = true;
							if ((User.ACCs & 0x10) == 0x0)
								Menu_ChangePass.Enabled = false;
							else
								Menu_ChangePass.Enabled = true;
							if ((User.ACCs & 0x10) == 0x0)
								PopMenuGrid4.Enabled = false;
							else
								PopMenuGrid4.Enabled = true;
							Menu_Classes.Enabled = false;
							Menu_Terms.Enabled = false;
							Menu_Delete_Entry_TermProg.Enabled = false;
							Menu_ReportTechPrograms.Visible = false; // under construction
							break;
							}
					}
				CheckMessages ();
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString (), "گزارش خطا در اجراي نکسترم", MessageBoxButtons.OK);
				}

			//Color Labels
			if ((User.ACCs & 0x4) == 0x0)
				{
				lbl_UserInactiveClass.ForeColor = Color.Red;
				}
			else
				{
				lbl_UserInactiveClass.ForeColor = Color.Blue;
				}
			if ((User.ACCs & 0x10) == 0x0)
				{
				lbl_UserInactiveProg.ForeColor = Color.Red;
				}
			else
				{
				lbl_UserInactiveProg.ForeColor = Color.Blue;
				}

			//label user type and name
			switch (User.Type)
				{
				case "UserDeputy":
						{
						lbl_UserType.Text = "کاربر معاون آموزشي";
						break;
						}
				case "UserOfficer":
						{
						lbl_UserType.Text = "کاربر کارشناس آموزشي";
						break;
						}
				case "UserDepartment":
						{
						lbl_UserType.Text = "کاربر " + User.Usrname; //"کاربر گروه"
						break;
						}
				}
			}
		private void CheckMessages ()
			{
			if (User.Type == "UserDeputy" | User.Type == "UserOfficer")
				User.Id = 0;
			NxDb.DS.Tables ["tblMSgs"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				try
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, usrFrom_ID, usrTo_ID, IsActive, msgString As [پيام], usrTo As [به], usrFrom As [از], SentDate As [زمان] FROM msgs WHERE usrTo_ID=" + User.Id.ToString () + " And IsActive = 1", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblMsgs");
					CnnSS.Close ();
					}
				catch (Exception ex)
					{
					CnnSS.Close ();
					MessageBox.Show (ex.ToString ());
					}
				}
			if (NxDb.DS.Tables ["tblMsgs"].Rows.Count > 0)
				{
				DialogResult myansw = (DialogResult) MessageBox.Show ("شما    " + NxDb.DS.Tables ["tblMsgs"].Rows.Count.ToString () + "   پيام خوانده نشده داريد\n\n" + "اکنون مي خوانيد؟", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
				if (myansw == DialogResult.Yes & User.Type != "UserOfficer")
					My.MyProject.Forms.frmShowNotes.ShowDialog ();
				}
			}
		private void ClrForm ()
			{
			//clear listbox 1,2 (Entries, Terms)
			NxDb.DS.Tables ["tblEntries"].Clear ();
			ComboBox1.SelectedIndex = -1;
			ComboBox1.SelectedValue = User.Id;
			NxDb.DS.Tables ["tblTerms"].Clear ();
			ListBox2.SelectedValue = -1;
			ListBox2.SelectedIndex = -1;
			Grid4.DataSource = "";
			txtExamDate.Text = "";
			GridWeek.Hide ();
			GridTime_Hide ();
			}
		private void ComboBox1_SelectedIndexChanged (object sender, EventArgs e)
			{
			//ComboBox1(=departments): populates listbox1(=entries)
			if (User.Type == "quit")
				return;
			//clear grid4(term_prog data)
			try
				{
				Menu_EntryProg_AllTerms.Enabled = false;
				Grid4.DataSource = "";
				txtExamDate.Text = "";
				GridTime_Hide ();
				NxDb.DS.Tables ["tblEntries"].Clear ();
				NxDb.DS.Tables ["tblTerms"].Clear ();
				string i = ComboBox1.GetItemText (ComboBox1.SelectedValue).ToString ();
				//MessageBox.Show (i);
				if (Convert.ToInt32 (i) == 0)
					return;
				if ((User.Type == "UserDepartment") & ((int) ComboBox1.SelectedValue != User.Id))
					return;
				if ((User.Type == "UserDepartment") & ((bool) NxDb.DS.Tables ["tblDepartments"].Rows [ComboBox1.SelectedIndex] [2] == false))
					return; //check if department is active: item(2):DepartmentActive

				//read (from DB) the entries of the selected department
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Entries.ID AS EntID, CONCAT(EntYear , ' - ' , ProgramName) As Prog, BioProg_ID FROM ((BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID) INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) WHERE Department_ID =" + i.ToString () + " AND Active = 1 ORDER BY EntYear, ProgramName", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblEntries");
					CnnSS.Close ();
					}
				//Populate ListBox1(the Entries)
				ListBox1.DataSource = NxDb.DS.Tables ["tblEntries"];
				ListBox1.DisplayMember = "Prog";
				ListBox1.ValueMember = "EntID";
				ListBox1.Refresh ();
				ListBox1.SelectedIndex = -1;
				ListBox1.SelectedValue = 0;
				// Clear ListBox2(the Terms)
				ListBox2.DataSource = null;
				ListBox2.Refresh ();
				ListBox2.SelectedIndex = -1;
				ListBox2.SelectedValue = 0;
				}
			catch (Exception ex)
				{
				//MessageBox.Show (ex.ToString ());
				}
			}
		private void ComboBox1_KeyDown (object sender, KeyEventArgs e)
			{
			if ((int) e.KeyCode == 37 | (int) e.KeyCode == 39) //37:l 39:r
				{
				ListBox1.Focus ();
				e.SuppressKeyPress = true;
				}
			}
		private void ListBox1_Click (object sender, EventArgs e)
			{
			lblExtraUnitsError.Visible = false;
			string i = "";
			try
				{
				i = ListBox1.GetItemText (ListBox1.SelectedValue);
				if (Convert.ToInt32 (i) == 0)
					return;
				}
			catch
				{
				return;
				}
			Menu_EntryProg_AllTerms.Enabled = true;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				try
					{
					NxDb.DS.Tables ["tblTerms"].Clear ();
					switch (User.Type)
						{
						case "UserDepartment": //show active terms
								{
								if ((User.ACCs & 0x8) == 0x0) //cannot!
									{
									CnnSS.Open ();
									NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" + i.ToString () + " AND Terms.[Active] = 1 ORDER BY Term", CnnSS);
									NxDb.DASS.Fill (NxDb.DS, "tblTerms");
									CnnSS.Close ();
									}
								else
									{
									CnnSS.Open ();
									NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" + i.ToString () + " ORDER BY Term", CnnSS);
									NxDb.DASS.Fill (NxDb.DS, "tblTerms");
									CnnSS.Close ();
									}
								break;
								}
						case "UserDeputy":  //show all terms
						case "UserOfficer": //show all terms
								{
								CnnSS.Open ();
								NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" + i.ToString () + " ORDER BY Term", CnnSS);
								NxDb.DASS.Fill (NxDb.DS, "tblTerms");
								CnnSS.Close ();
								break;
								}
						}
					}
				catch (Exception ex)
					{
					CnnSS.Close ();
					MessageBox.Show (ex.ToString ());
					}
				}
			ListBox2.DataSource = NxDb.DS.Tables ["tblTerms"];
			ListBox2.DisplayMember = "Term";
			ListBox2.ValueMember = "ID";
			ListBox2.Refresh ();
			ListBox2.SelectedIndex = -1;
			ListBox2.SelectedValue = 0;
			Grid4.DataSource = "";
			txtExamDate.Text = "";
			GridTime_Hide ();
			if (ListBox2.Items.Count > 0 & TermProg.DefaultTermId > 0)
				{
				ListBox2.SelectedValue = TermProg.DefaultTermId;
				ListBox2_Click (sender, e);
				}
			}
		private void ListBox1_KeyDown (object sender, KeyEventArgs e)
			{
			switch ((int) e.KeyCode)
				{
				case 39: //right
						{
						ComboBox1.Focus ();
						e.SuppressKeyPress = true;
						break;
						}
				case 13:
						{
						ListBox1_Click (sender, e);
						e.SuppressKeyPress = true;
						break;
						}
				case 37: //left
						{
						ListBox1_Click (null, null);
						Grid4.Focus ();
						e.SuppressKeyPress = true;
						break;
						}
				}
			}
		private void ListBox2_Click (object sender, EventArgs e)
			{
			ListBox2CLICKED ();
			}
		private void ListBox2CLICKED ()
			{
			//reset (hide) popup menu in grid4
			Grid4PopupMenuItems (0);
			try
				{
				Entry.Id = Convert.ToInt32 (ListBox1.GetItemText (ListBox1.SelectedValue));
				Term.Id = Convert.ToInt32 (ListBox2.GetItemText (ListBox2.SelectedValue));
				if (Entry.Id == 0)
					return;
				if (Term.Id == 0)
					return;
				}
			catch
				{
				return;
				}

			//check if (Term Active?) OR (User Faculty?)
			Term.Active = (bool) (NxDb.DS.Tables ["tblTerms"].Rows [ListBox2.SelectedIndex] [5]);
			Term.ExamDateStart = (NxDb.DS.Tables ["tblterms"].Rows [ListBox2.SelectedIndex] [2].ToString ());
			Term.ExamDateEnd = (NxDb.DS.Tables ["tblterms"].Rows [ListBox2.SelectedIndex] [3].ToString ());
			NxDb.DS.Tables ["tblTermProgs"].Clear ();
			if ((User.Type == "UserDepartment") & (Term.Active == false) & ((User.ACCs & 0x8) == 0x0))
				{
				MessageBox.Show ("ويرايش برنامه اين ترم فعال نشده است", "NexTerm", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			Grid4.DataBindings.Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				try
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName AS [درس], Units, [Group] AS [گ], Staff_ID, Staff.StaffName AS [استاد], Tech_ID, Technecians.StaffName AS [کارشناس], SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName AS [کلاس1], SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName AS [کلاس2], Capacity AS [ت], ExamDate, TermProgs.Notes AS [يادداشت]  FROM ((((((Rooms Rooms_1 RIGHT OUTER JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT OUTER JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT OUTER JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT OUTER JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT OUTER JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT OUTER JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) WHERE Term_ID = " + Term.Id.ToString () + " AND Entry_ID = " + Entry.Id.ToString () + " ORDER BY CourseName, [Group]", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblTermProgs");
					CnnSS.Close ();
					}
				catch (Exception ex)
					{
					CnnSS.Close ();
					MessageBox.Show (ex.ToString ());
					}
				}
			Grid4.DataSource = NxDb.DS.Tables ["tblTermProgs"];
			Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			// hide some cols
			Grid4.Columns [0].Visible = false;    //ID
			Grid4.Columns [1].Visible = false;    //Course ID
			Grid4.Columns [2].Visible = false;    //Course Number
			Grid4.Columns [3].Width = 200;        //CourseName
			Grid4.Columns [4].Width = 25;         //Units
			Grid4.Columns [5].Width = 20;         //Group
			Grid4.Columns [6].Visible = false;    //Staff ID
			Grid4.Columns [7].Width = 125;        //StaffName
			Grid4.Columns [8].Visible = false;    //Tech ID
			Grid4.Columns [9].Width = 105;        //TechName
			Grid4.Columns [10].Visible = false;   //SAT 1
			Grid4.Columns [11].Visible = false;   //SUN 1
			Grid4.Columns [12].Visible = false;   //MON 1
			Grid4.Columns [13].Visible = false;   //TUE 1
			Grid4.Columns [14].Visible = false;   //WED 1
			Grid4.Columns [15].Visible = false;   //THR 1
			Grid4.Columns [16].Visible = false;   //Room 1
			Grid4.Columns [17].Width = 100;       //Room1Name
			Grid4.Columns [18].Visible = false;   //SAT 2
			Grid4.Columns [19].Visible = false;   //SUN 2
			Grid4.Columns [20].Visible = false;   //MON 2
			Grid4.Columns [21].Visible = false;   //TUE 2
			Grid4.Columns [22].Visible = false;   //WED 2
			Grid4.Columns [23].Visible = false;   //THR 2
			Grid4.Columns [24].Visible = false;   //Room 2
			Grid4.Columns [25].Width = 75;        //Room2Name
			Grid4.Columns [26].Width = 32;        //Capacity
			if (MenuShowCourseNote.Checked == true)
				{
				Grid4.Columns [27].Visible = false;   //ExamDate
				Grid4.Columns [28].Visible = true;    //Note
				Grid4.Columns [28].Width = 180;       //Note
				}
			else if (MenuShowCourseExamDate.Checked == true)
				{
				Grid4.Columns [27].Visible = true;    //ExamDate
				Grid4.Columns [28].Visible = false;   //Note
				Grid4.Columns [27].Width = 180;       //ExamDate
				}
			txtExamDate.Text = "";
			GridTime_Hide ();
			GridWeek_Show ();
			for (int i = 0, loopTo = Grid4.Columns.Count - 1; i <= loopTo; i++)
				Grid4.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
			}
		//8term progs for an entry
		private void Menu_EntryProg_AllTerms_Click (object sender, EventArgs e)
			{
			//Show 8-term TermProgs for this Entry
			if (ListBox1.SelectedIndex == -1 || ListBox2.SelectedIndex == -1)
				return;
			int Ent = (int) ListBox1.SelectedValue;
			int Trm = (int) ListBox2.SelectedValue;
			if (Ent == 0)
				return;
			Entry.Name = ListBox1.Text;
			NxDb.DS.Tables ["tblAllProgs"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				try
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Entry_ID = " + Ent.ToString () + ") ORDER BY Term, THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
					}
				catch (Exception ex)
					{
					MessageBox.Show (ex.ToString ());
					}
				CnnSS.Close ();
				}
			//PRINT
			FileSystem.FileOpen (1, System.Windows.Forms.Application.StartupPath + @"\Nexterm_Entry.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>برنامه يک ورودي</title>");
			FileSystem.PrintLine (1, Report.Style);
			FileSystem.PrintLine (1, "</head>");
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h1 style='color:blue; text-align:center'>", Entry.Name, "</h1>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align:center'>برنامه ترميک يک ورودي</h2>");
			FileSystem.PrintLine (1, "<hr>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه ترميک اين ورودي</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			string strTermName = "";
			for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
				{
				if (strTermName != NxDb.DS.Tables ["tblAllProgs"].Rows [i] [30].ToString ()) // reached Next Term
					{
					strTermName = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [30].ToString ();
					FileSystem.PrintLine (1, "<tr><td>^</td></tr>");
					FileSystem.PrintLine (1, "<tr><th>ترم</th><th>شماره</th><th>گ</th><th>نام درس</th><th>واحد</th><th>نام مدرس</th><th>يادداشت</th></tr>");
					}
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [30], "</td>");  //30 :Term
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   //2  :CourseNumber
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   //5  :Group
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   //3  :CourseName
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   //4  :Unit
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   //7  :Staff
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>");  //28 :Note
				FileSystem.PrintLine (1, "</tr>");
				}
			FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			//FOOTER
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_Entry.html");
			}
		private void Menu_Guide_Click (object sender, EventArgs e)
			{
			FileSystem.FileOpen (1, System.Windows.Forms.Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir=\"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>راهنماس</title>");
			FileSystem.PrintLine (1, Report.Style); //strReportsStyle is defined in Module1
			FileSystem.PrintLine (1, "</head>");
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>");
			FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>راهنماي نرم افزار نکسترم</p>");
			FileSystem.PrintLine (1, "<hr>");
			FileSystem.PrintLine (1, "<p style='color:green;font-family:tahoma; font-size:14px'> راهنماي استفاده از نکسترم <br></p>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
			FileSystem.PrintLine (1, "راهنماي مصور نکسترم را در وبسايت زير (بخش نکسترم) ببينيد  <br>");
			FileSystem.PrintLine (1, "<a href=\"http://msht.ir/NexTerm_00.html\">msht.ir</a>  <br>");
			FileSystem.PrintLine (1, " <br>");
			FileSystem.PrintLine (1, "در شروع استفاده از نکسترم، راه اندازي اوليه (توسط ادمين نکسترم) بصورت زير انجام شود <br>");
			FileSystem.PrintLine (1, " <br>");
			FileSystem.PrintLine (1, "</p> <br>");
			FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> براي آموزش دانشکده <br></p>");
			FileSystem.PrintLine (1, " <br>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
			FileSystem.PrintLine (1, "ليست گروه هاي آموزشي دانشکده در بخش منابع واردشود <br>");
			FileSystem.PrintLine (1, "ليست کارشناسان آزمايشگاه ها در بخش منابع واردشود <br>");
			FileSystem.PrintLine (1, "ليست کلاس ها و آزمايشگاه ها در بخش منابع واردشود <br>");
			FileSystem.PrintLine (1, " <br>");
			FileSystem.PrintLine (1, "</p> <br>");
			FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> براي مدير گروه آموزشي <br></p>");
			FileSystem.PrintLine (1, " <br>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
			FileSystem.PrintLine (1, "ليست اساتيد گروه (در بخش منابع) واردشده باشند  <br>");
			FileSystem.PrintLine (1, "ليست دوره هاي آموزشي گروه (در بخش منابع) واردشده باشند <br>");
			FileSystem.PrintLine (1, "دربخش منابع، براي هر دوره آموزشي ليست درس ها واردشده باشند  <br>");
			FileSystem.PrintLine (1, "دربخش منابع، براي هر دوره آموزشي ليست ورودي هاي فعال واردشده باشند  <br>");
			FileSystem.PrintLine (1, " <br>");
			FileSystem.PrintLine (1, "براي هر دوره آموزشي دست کم يک برنامه الگو (ترميک) طراحي و ثبت شده باشد <br>");
			FileSystem.PrintLine (1, "به هر ورودي فعال، برنامه الگو اختصاص داده شده باشد <br>");
			FileSystem.PrintLine (1, "برنامه پيش روي هر ورودي بررسي شده باشد تا دانشجويان هر ورودي بتوانند نهايتا در ترمي که تعيين شده، فارغ التحصيل شوند <br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, "آموزش مصور و فيلم هاي آموزشي مربوط به نکسترم را در وبسايت زير (در بخش نکسترم) ببينيد<br>");
			FileSystem.PrintLine (1, "<br></p>");
			FileSystem.PrintLine (1, "<a href=\"http://msht.ir/NexTerm_00.html\">msht.ir</a>  <br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body>");
			FileSystem.PrintLine (1, "</html>");
			FileSystem.FileClose (1);
			Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
			}
		private void DrawFreeTimeTable ()
			{
			try
				{
				string strTableTag = "";
                FileSystem.PrintLine (1, "<center>");
                FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-6\">");
                FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<th>روز</th>");
				FileSystem.PrintLine (1, "<th>08:30</th>");
				FileSystem.PrintLine (1, "<th>09:30</th>");
				FileSystem.PrintLine (1, "<th>10:30</th>");
				FileSystem.PrintLine (1, "<th>11:30</th>");
				FileSystem.PrintLine (1, "<th>13:30</th>");
				FileSystem.PrintLine (1, "<th>14:30</th>");
				FileSystem.PrintLine (1, "<th>15:30</th>");
				FileSystem.PrintLine (1, "<th>16:30</th>");
				FileSystem.PrintLine (1, "</tr>");
				for (int d = 0; d <= 5; d++)
					{
					FileSystem.PrintLine (1, "<tr>");
					FileSystem.PrintLine (1, "<td>" + TermProg.Day [d] + "</th>");
					for (int i = 0; i <= 7; i++)
						{
						if (TermProg.TimeFlag [d, i] > 1d)
							{
							strTableTag = "<td style=text-align:center;background-color:yellow;>";
							}
						else if (TermProg.TimeFlag [d, i] == 1d)
							{
							strTableTag = "<td style=text-align:center;background-color:white;>";
							}
						else
							{
							strTableTag = "<td style=text-align:center;>";
							}
						if (TermProg.TimeFlag [d, i] == 0)
							{
							FileSystem.PrintLine (1, strTableTag, "</td>"); //08:30-16:30
							}
						else
							{
							FileSystem.PrintLine (1, strTableTag, TermProg.TimeFlag [d, i], "</td>");
							} //08:30-16:30
						}
					FileSystem.PrintLine (1, "</tr>");
					}
				FileSystem.PrintLine (1, "</table>");
                FileSystem.PrintLine (1, "</div>");
                FileSystem.PrintLine (1, "</center>");
				FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p>");
				}
			catch (Exception ex)
				{
				MessageBox.Show ("Error drawing free time table \n" + ex.ToString (), "nexterm", MessageBoxButtons.OK);
				}
			}
		//Grid week
		private void GridWeek_CellClick (object sender, DataGridViewCellEventArgs e)
			{
			try
				{
				if (e.RowIndex == -1)
					return;
				Entry.Name = ListBox1.Text;
				Term.Name = ListBox2.Text;
				int r = e.RowIndex;    // count from 0
				int c = e.ColumnIndex; // count from 0
				if (r < 0 | c < 0)
					return;
				string strTadakholMessage = "";
				if ((int) GridWeek [c, r].Value > 0)
					{
					for (int i = 0, loopTo = NxDb.DS.Tables ["tblTermProgs"].Rows.Count - 1; i <= loopTo; i++)
						{
						if (((Convert.ToInt32 (NxDb.DS.Tables ["tblTermProgs"].Rows [i] [r + 10].ToString ()) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))) | ((Convert.ToInt32 (NxDb.DS.Tables ["tblTermProgs"].Rows [i] [r + 18].ToString ()) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))))
							{
							strTadakholMessage = strTadakholMessage + NxDb.DS.Tables ["tblTermProgs"].Rows [i] [3].ToString () + "    گروه:  " + NxDb.DS.Tables ["tblTermProgs"].Rows [i] [5].ToString () + "\n استاد: " + NxDb.DS.Tables ["tblTermProgs"].Rows [i] [7].ToString () + "\n\n";
							}
						}
					MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
					}
				}
			catch (Exception ex)
				{
				//MessageBox.Show (ex.ToString ());
				}
			}
		private void MenuGridWeekReport_Click (object sender, EventArgs e)
			{
			ListBox2_Click (sender, e); //enforce  GridWeek_Show() in ListBox2:Terms
			Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_EntryTerm.html");
			}
		private void MenuGridWeek_Export_Click (object sender, EventArgs e)
			{
			//Export
			FileSystem.FileClose (1);
			using (var dialog = new SaveFileDialog () { InitialDirectory = Application.StartupPath, Filter = "Nexterm Term Progs|*.xlsx" })
				{
				if (dialog.ShowDialog () == DialogResult.OK)
					{
					NxDb.Filename = dialog.FileName;
					}
				else
					{
					return;
					}
				}
			using (IXLWorkbook WB = new XLWorkbook ())
				{
				try
					{
					var WS0 = WB.Worksheets.Add ("NexTerm TermProgs");
					WS0.Cell (1, 1).Value = "Number";
					WS0.Cell (1, 2).Value = "CourseName";
					WS0.Cell (1, 3).Value = "Units";
					WS0.Cell (1, 4).Value = "Group";
					WS0.Cell (1, 5).Value = "Capacity";
					WS0.Cell (1, 6).Value = "Staff";
					WS0.Cell (1, 7).Value = "Tech";
					WS0.Cell (1, 8).Value = "Notes";
					for (int i = 0, loopTo = Grid4.Rows.Count - 1; i <= loopTo; i++)
						{
						WS0.Cell (i + 2, 1).Value = Grid4 [2, i].Value.ToString ();     //CourseNumber
						WS0.Cell (i + 2, 2).Value = Grid4 [3, i].Value.ToString ();     //CourseName
						WS0.Cell (i + 2, 3).Value = Grid4 [4, i].Value.ToString ();     //Units
						WS0.Cell (i + 2, 4).Value = Grid4 [5, i].Value.ToString ();     //Group
						WS0.Cell (i + 2, 5).Value = Grid4 [26, i].Value.ToString ();    //Capacity
						WS0.Cell (i + 2, 6).Value = Grid4 [7, i].Value.ToString ();     //Staff
						WS0.Cell (i + 2, 7).Value = Grid4 [9, i].Value.ToString ();     //Tech
						WS0.Cell (i + 2, 8).Value = Grid4 [28, i].Value.ToString ();    //Notes
						}
					}
				catch (Exception ex)
					{
					MessageBox.Show ("Error In Exporting Courses" + ex.ToString ());
					return;
					}
				//Save Excel
				WB.SaveAs (NxDb.Filename);
				NxDb.LOG ("entry prog to excel");
				MessageBox.Show ("ليست برنامه ترم اين ورودي در فولدر برنامه ذخيره شد\n\n" + NxDb.Filename, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				}
			}
		private void GridWeek_Show ()
			{
			int Ent = (int) ListBox1.SelectedValue;
			int Trm = (int) ListBox2.SelectedValue;
			if (Ent == 0)
				return;
			if (Trm == 0)
				return;
			//Clear GridWeek
			for (int c = 1; c <= 8; c++)     //cols are day_times
				{
				for (int r = 0; r <= 5; r++) //rows are week_days
					{
					GridWeek [c, r].Value = "";
					GridWeek [c, r].Style.ForeColor = Color.Black;
					}
				}
			GridWeek.Visible = true;
			// Grid4.Cols:  6=SAT ... 11=THR
			Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); //clear data in intTimeFlag (r:6days, c:8times //begins from 0)
			string strTadakhol = "";
			bool TadakholExists = false;
			Entry.Name = ListBox1.Text;
			Term.Name = ListBox2.Text;
            strTadakhol = "<center>";
            strTadakhol += "<div class= \"table-responsive col-md-4\">";
            strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
			strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th></tr>";
			for (int intThisCourse = 0, loopTo = NxDb.DS.Tables ["tblTermProgs"].Rows.Count - 1; intThisCourse <= loopTo; intThisCourse++)
				{
				for (int intTime = 0; intTime <= 7; intTime++) //for each time of day
					{
					for (int intDay = 0; intDay <= 5; intDay++)
						{
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [intThisCourse] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))) // if time[2^0] is set //item(10):SAT1
							{
							TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
							GridWeek [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
							if (TermProg.TimeFlag [intDay, intTime] > 1)
								{
								strTadakhol = Conversions.ToString (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>" + NxDb.DS.Tables ["tblTermProgs"].Rows [intThisCourse] [3] + "</td><td>" + NxDb.DS.Tables ["tblTermProgs"].Rows [intThisCourse] [5] + "</td></tr>" + "\n");
								TadakholExists = true;
								}
							}
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [intThisCourse] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))) // if time[2^0] is set //item(18):SAT2
							{
							TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
							GridWeek [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
							if (TermProg.TimeFlag [intDay, intTime] > 1)
								{
								strTadakhol = Conversions.ToString (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>" + NxDb.DS.Tables ["tblTermProgs"].Rows [intThisCourse] [3] + "</td><td>" + NxDb.DS.Tables ["tblTermProgs"].Rows [intThisCourse] [5] + "</td></tr>" + "\n");
								TadakholExists = true;
								}
							}
						}
					}
				}
			strTadakhol += "</table>";
            strTadakhol += "</div>";
            strTadakhol += "</center>";
			//OPEN Week()
			FileSystem.FileOpen (1, Application.StartupPath + @"\Nexterm_EntryTerm.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>برنامه ورودي</title>");
			FileSystem.PrintLine (1, Report.Style); //strReportsStyle is defined in Module1
			FileSystem.PrintLine (1, "</head>");
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h1 style='color:blue; text-align:center'>", Entry.Name, "</h1>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align:center'>", Term.Name, "</h2><hr>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
			if (TadakholExists == true)
				{
				FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
				FileSystem.PrintLine (1, strTadakhol);
				FileSystem.PrintLine (1, "<br>");
				}
			//draw table2: TermProg (html)
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه آموزشي</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			FileSystem.PrintLine (1, "<tr><th>شماره</th>");
			FileSystem.PrintLine (1, "<th>گ</th>");
			FileSystem.PrintLine (1, "<th>نام درس</th>");
			FileSystem.PrintLine (1, "<th>واحد</th>");
			FileSystem.PrintLine (1, "<th>نام مدرس</th>");
			FileSystem.PrintLine (1, "<th>کارشناس</th>");
			FileSystem.PrintLine (1, "<th>ش</th>");
			FileSystem.PrintLine (1, "<th>ي</th>");
			FileSystem.PrintLine (1, "<th>د</th>");
			FileSystem.PrintLine (1, "<th>س</th>");
			FileSystem.PrintLine (1, "<th>چ</th>");
			FileSystem.PrintLine (1, "<th>پ</th>");
			FileSystem.PrintLine (1, "<th>امتحان</th>");
			FileSystem.PrintLine (1, "<th>کلاس1</th>");
			FileSystem.PrintLine (1, "<th>کلاس2</th>");
			FileSystem.PrintLine (1, "<th>ظرفيت</th>");
			FileSystem.PrintLine (1, "<th>يادداشت</th></tr>");
			for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblTermProgs"].Rows.Count - 1; i <= loopTo1; i++)
				{
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [2], "</td>");   //2 :CourseNumber
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [5], "</td>");   //5 :Group
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [3], "</td>");   //3 :CourseName
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [4], "</td>");   //4 :Unit
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [7], "</td>");   //7 :Staff
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [9], "</td>");   //9 :Tech
				for (int intday = 0; intday <= 5; intday++)
					{
					string x = "";
					for (int intTime = 0; intTime <= 7; intTime++)
						{
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
							{
							x = x + TermProg.Time [intTime] + "<br>"; //Time
							}
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
							{
							x = x + TermProg.Time [intTime] + "<br>"; //Time
							}
						}
					FileSystem.PrintLine (1, "<td>", x, "</td>");       //Time
					}
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [27], "</td>"); //27:Exam
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [17], "</td>"); //17:Class1
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [25], "</td>"); //25:Class2
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [26], "</td>"); //26:Capacity
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermProgs"].Rows [i] [28], "</td>"); //28:Notes
				FileSystem.PrintLine (1, "</tr>");
				}
			FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			// table: free times
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
			DrawFreeTimeTable ();
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
			// table of Exams dates for GridWeek
			NxDb.DS.Tables ["tblTermExams"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt, Entry_ID FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Trm.ToString () + " AND Entry_ID = " + Ent.ToString () + " ORDER BY ExamDate", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
				CnnSS.Close ();
				}
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
			FileSystem.PrintLine (1, "برنامه امتحانات");
			FileSystem.PrintLine (1, "</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			FileSystem.PrintLine (1, "<tr>");
			FileSystem.PrintLine (1, "<th>تاريخ</th><th>درس</th><th>استاد</th></tr>");
			for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo2; i++)
				{
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [1], "</td>");  //1 :Exam
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [2], "</td>");  //2 :Course
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [5], "</td>");  //5 :Staff
				FileSystem.PrintLine (1, "</tr>");
				}
			FileSystem.PrintLine (1, "</table>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			//FOOTER
			FileSystem.PrintLine (1, "<br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					{
					if (Conversion.Val (GridWeek [c, r].Value) > 1d)
						GridWeek [c, r].Style.ForeColor = Color.Red;
					}
				}
			GridWeek.Visible = true;
			}
		//Grid4
		private void Grid4_KeyDown (object sender, KeyEventArgs e)
			{
			try
				{
				switch ((int) e.KeyCode)
					{
					case 39: //right
							{
							if (Grid4.SelectedCells [0].ColumnIndex == 3)
								{
								ListBox1.Focus ();
								e.SuppressKeyPress = true;
								break;
								}
							break;
							}
					case 13:
							{
							if (Grid4.SelectedCells [0].ColumnIndex == 3)
								{
								//not for courses! (caution)
								Grid4_CellClick (null, null);
								e.SuppressKeyPress = true;
								return;
								}
							else
								{
								Grid4_CellDblClick (sender, null);
								e.SuppressKeyPress = true;
								}
							break;
							}
					case 27:
							{
							switch (Grid4.SelectedCells [0].ColumnIndex)
								{
								case 3: //Courses
										{
										ListBox1.Focus ();
										e.SuppressKeyPress = true;
										break;
										}
								case 7: //Staff
										{
										DelStaff ();
										e.SuppressKeyPress = true;
										break;
										}
								case 9: //Tech
										{
										DelTech ();
										e.SuppressKeyPress = true;
										break;
										}
								case 17: //Room1
										{
										DelClass1 ();
										e.SuppressKeyPress = true;
										break;
										}
								case 25: //Room2
										{
										DelClass2 ();
										e.SuppressKeyPress = true;
										break;
										}
								}
							e.SuppressKeyPress = true;
							break;
							}
					}
				}
			catch
				{
				}
			}
		private void Grid4_CellDblClick (object sender, DataGridViewCellEventArgs e)
			{
			lblExtraUnitsError.Visible = false;
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;

			//fill data in WeekTable
			FeedGridWeek ();

			//do base on grid4.col
			switch (c)
				{
				case 3: //Course
						{
						EditCourse ();
						break;
						}
				case 5: //Group
						{
						EditGroup ();
						break;
						}
				case 7: //Staff
						{
						SetStaff ();
						break;
						}
				case 9: //Tech
						{
						SetTech ();
						break;
						}
				case 17: //Room1
						{
						SetClass1 ();
						break;
						}
				case 25: //Room2
						{
						SetClass2 ();
						break;
						}
				case 26: //Capacity
						{
						SetCapacity ();
						break;
						}
				case 27: //ExamDate
						{
						SetExamDate ();
						break;
						}
				case 28: //Notes
						{
						SetNote ();
						break;
						}
				}
			ListBox2_Click (sender, e);
			}
		private void Grid4_CellClick (object sender, DataGridViewCellEventArgs e)
			{
			lblExtraUnitsError.Visible = false;
			for (int cl = 1; cl <= 8; cl++)
				{
				for (int rw = 0; rw <= 5; rw++)
					{
					GridTime [cl, rw].Value = "";
					GridTime [cl, rw].Style.ForeColor = Color.Black;
					GridTime [cl, rw].Style.BackColor = Color.White;
					}
				}
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			Grid4PopupMenuItems (c);

			if (r < 0)
				return;
			if (Grid4 [c, r].Value is null || Grid4 [c, r].Value is DBNull)
				return;
			//selective popup menus based on column of grid4
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
			Term.Name = ListBox2.Text;
			switch (c)
				{
				case 3:
						{
						TermProg.Caption = "Course";
						Course.Name = Conversions.ToString (Grid4 [c, r].Value);
						GridTime_ShowCourse (); //codes in this form (me)
						break;
						}
				case 7:
						{
						TermProg.Caption = "Staff";
						Staff.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [6]);
						Staff.Name = Conversions.ToString (Grid4 [c, r].Value);
						GridTime_ShowStaff (); //in this form (me)
						break;
						}
				case 9:
						{
						TermProg.Caption = "Tech";
						Tech.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [8]);
						Tech.Name = Conversions.ToString (Grid4 [c, r].Value);
						GridTime_ShowTech (); //in this form (me)
						break;
						}
				case 17:
						{
						TermProg.Caption = "Room";
						TermProg.Roomx = 1;
						if (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [16] is null || NxDb.DS.Tables ["tblTermProgs"].Rows [r] [16] is DBNull)
							NxDb.DS.Tables ["tblTermProgs"].Rows [r] [16] = 0;
						Room.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [16]);
						Room.Name = Conversions.ToString (Grid4 [c, r].Value);
						GridTime_ShowRoom (); //in this form (me)
						break;
						}
				case 25:
						{
						TermProg.Caption = "Room";
						TermProg.Roomx = 2;
						if (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [24] is null || NxDb.DS.Tables ["tblTermProgs"].Rows [r] [24] is DBNull)
							NxDb.DS.Tables ["tblTermProgs"].Rows [r] [24] = 0;
						Room.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [24]);
						Room.Name = Conversions.ToString (Grid4 [c, r].Value);
						GridTime_ShowRoom (); //in this form (me)
						break;
						}
				default:
						{
						return;
						}
				}
			}
		//Grid4 - popup menu
		private void PopMenu_AddCourse (object sender, EventArgs e)
			{
			AddCourse ();
			ListBox2_Click (sender, e);
			}
		private void MenuEditCourse_Click (object sender, EventArgs e)
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			EditCourse ();
			}
		private void Menu_ReplaceCourse (object sender, EventArgs e)
			{
			ReplaceCourse ();
			// Refresh
			ListBox1_Click (sender, e);
			ListBox2.SelectedIndex = 0;
			ListBox2_Click (sender, e);
			}
		private void PopMenu_DelCourse (object sender, EventArgs e)
			{
			DelCourse ();
			ListBox2_Click (sender, e);
			}
		private void MenuAddGroup1_Click (object sender, EventArgs e)
			{
			AddGroup ();
			ListBox2_Click (sender, e);
			}
		private void PopMenu_AddGroup (object sender, EventArgs e)
			{
			AddGroup ();
			ListBox2_Click (sender, e);
			}
		private void MenuEditGroup_Click (object sender, EventArgs e)
			{
			EditGroup ();
			}
		private void MenuSetStaff_Click (object sender, EventArgs e)
			{
			SetStaff ();
			}
		private void MenuDelStaff_Click (object sender, EventArgs e)
			{
			DelStaff ();
			}
		private void MenuSetTech_Click (object sender, EventArgs e)
			{
			SetTech ();
			}
		private void MenuDelTech_Click (object sender, EventArgs e)
			{
			DelTech ();
			}
		private void MenuSetClass1_Click (object sender, EventArgs e)
			{
			SetClass1 ();
			}
		private void MenuDelClass1_Click (object sender, EventArgs e)
			{
			DelClass1 ();
			}
		private void MenuSetClass2_Click (object sender, EventArgs e)
			{
			SetClass2 ();
			}
		private void MenuDelClass2_Click (object sender, EventArgs e)
			{
			DelClass2 ();
			}
		private void MenuNumberOfStudents_Click (object sender, EventArgs e)
			{
			SetCapacity ();
			}
		private void MenuShowCourseNote_Click (object sender, EventArgs e)
			{
			MenuShowCourseNote.Checked = true;
			MenuShowCourseExamDate.Checked = false;
			ListBox2_Click (sender, e);
			}
		private void MenuShowCourseExamDate_Click (object sender, EventArgs e)
			{
			MenuShowCourseNote.Checked = false;
			MenuShowCourseExamDate.Checked = true;
			ListBox2_Click (sender, e);
			}
		private void PopMenu_SaveWeekGrid (object sender, EventArgs e)
			{
			int r = Grid4.CurrentCell.RowIndex;
			int c = Grid4.CurrentCell.ColumnIndex;
			int unt = Conversions.ToInteger (Conversion.Int (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [4]));
			int A = 0; // this cell
			int B = 0; // previous cell
			int Cnt = 0; // counter
						 // 1: Check and recolor GridTime cells
			for (int intDay = 0; intDay <= 5; intDay++)
				{
				for (int intTime = 1; intTime <= 8; intTime++)
					{
					A = intTime + 8 * (intDay - 1);
					if (Operators.ConditionalCompareObjectNotEqual (GridTime [intTime, intDay].Value, "", false))
						{
						Cnt = Cnt + 1;
						switch (Cnt)
							{
							case 1:
									{
									GridTime [intTime, intDay].Style.BackColor = Color.LightCyan;
									break;
									}
							case 2:
									{
									if (A - B == 1)
										{
										GridTime [intTime, intDay].Style.BackColor = Color.LightCyan;
										}
									else
										{
										GridTime [intTime, intDay].Style.BackColor = Color.MistyRose;
										}

									break;
									}
							case 3:
							case 4:
									{
									if (Cnt <= unt)
										{
										GridTime [intTime, intDay].Style.BackColor = Color.MistyRose;
										}
									else
										{
										// GridTime(intTime, intDay).Style.BackColor = Color.White
										GridTime [intTime, intDay].Style.BackColor = Color.MistyRose;
										lblExtraUnitsError.Visible = true;
										} // 5, more

									break;
									}
							default:
									{
									// GridTime(intTime, intDay).Style.BackColor = Color.White
									GridTime [intTime, intDay].Style.BackColor = Color.MistyRose;
									lblExtraUnitsError.Visible = true;
									break;
									}
							}
						B = A;
						}
					else
						{
						GridTime [intTime, intDay].Style.BackColor = Color.White;
						}
					}
				}
			// 2: Compute
			try
				{
				NxDb.DS.Tables ["tblTermProgs"].Rows [r] [27] = txtExamDate.Text;
				}
			catch (Exception ex)
				{
				MessageBox.Show ("Error in SaveGrid: NOT SAVED !", "NexTerm", MessageBoxButtons.OK);
				}
			for (int intDay = 0; intDay <= 5; intDay++)
				{
				TermProg.Class1DayData [intDay] = 0; // reset a day in class1 and then refill
				TermProg.Class2DayData [intDay] = 0; // reset a day in class2 and then refill
				for (int intTime = 1; intTime <= 8; intTime++)
					{
					if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectNotEqual (GridTime [intTime, intDay].Value, "", false), GridTime [intTime, intDay].Style.BackColor == Color.LightCyan)))
						{
						TermProg.Class1DayData [intDay] = (int) ((long) TermProg.Class1DayData [intDay] | (long) Math.Round (Math.Pow (2d, intTime - 1)));
						}
					if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectNotEqual (GridTime [intTime, intDay].Value, "", false), GridTime [intTime, intDay].Style.BackColor == Color.MistyRose)))
						{
						TermProg.Class2DayData [intDay] = (int) ((long) TermProg.Class2DayData [intDay] | (long) Math.Round (Math.Pow (2d, intTime - 1)));
						}
					}
				NxDb.DS.Tables ["tblTermProgs"].Rows [r] [intDay + 10] = Conversion.Val (TermProg.Class1DayData [intDay]);
				NxDb.DS.Tables ["tblTermProgs"].Rows [r] [intDay + 18] = Conversion.Val (TermProg.Class2DayData [intDay]);
				}
			// 3: Save to db
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "UPDATE TermProgs SET SAT1=@sat1, SUN1=@sun1, MON1=@mon1, TUE1=@tue1, WED1=@wed1, THR1=@thr1, SAT2=@sat2, SUN2=@sun2, MON2=@mon2, TUE2=@tue2, WED2=@wed2, THR2=@thr2, ExamDate=@ExamDate WHERE ID=@ID";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@sat1", Conversion.Val (TermProg.Class1DayData [0]));
					cmd.Parameters.AddWithValue ("@sun1", Conversion.Val (TermProg.Class1DayData [1]));
					cmd.Parameters.AddWithValue ("@mon1", Conversion.Val (TermProg.Class1DayData [2]));
					cmd.Parameters.AddWithValue ("@tue1", Conversion.Val (TermProg.Class1DayData [3]));
					cmd.Parameters.AddWithValue ("@wed1", Conversion.Val (TermProg.Class1DayData [4]));
					cmd.Parameters.AddWithValue ("@thr1", Conversion.Val (TermProg.Class1DayData [5]));
					cmd.Parameters.AddWithValue ("@sat2", Conversion.Val (TermProg.Class2DayData [0]));
					cmd.Parameters.AddWithValue ("@sun2", Conversion.Val (TermProg.Class2DayData [1]));
					cmd.Parameters.AddWithValue ("@mon2", Conversion.Val (TermProg.Class2DayData [2]));
					cmd.Parameters.AddWithValue ("@tue2", Conversion.Val (TermProg.Class2DayData [3]));
					cmd.Parameters.AddWithValue ("@wed2", Conversion.Val (TermProg.Class2DayData [4]));
					cmd.Parameters.AddWithValue ("@thr2", Conversion.Val (TermProg.Class2DayData [5]));
					cmd.Parameters.AddWithValue ("@ExamDate", txtExamDate.Text);
					cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				GridWeek_Show ();
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				// MsgBox("Error Saving Changes", vbOKOnly, "Err")
				}
			}
		private void Menu_ExitNexTerm_Click (object sender, EventArgs e)
			{
			DoExitNexTerm ();
			}
		//Grid4 - methods
		private void Grid4PopupMenuItems (int col)
			{
			/*
			 * selective popup menus based on column of grid4
			 * usage as: Grid4PopupMenuItems (c)
			 * in:
			 *   1 form load
			 *   2 listbox2
			 *   3 grid4 click
			*/

			//first: hide all
			MenuAddCourse.Visible = false;
			MenuEditCourse.Visible = false;
			MenuReplaceCourse.Visible = false;
			MenuDelCourse.Visible = false;
			MenuAddGroup1.Visible = false;
			MenuLine1.Visible = false;
			MenuAddGroup.Visible = false;
			MenuEditGroup.Visible = false;
			MenuSetStaff.Visible = false;
			MenuDelStaff.Visible = false;
			MenuSetTech.Visible = false;
			MenuDelTech.Visible = false;
			MenuSetClass1.Visible = false;
			MenuDelClass1.Visible = false;
			MenuSetClass2.Visible = false;
			MenuDelClass2.Visible = false;
			MenuNumberOfStudents.Visible = false;
			MenuShowCourseNote.Visible = false;
			MenuShowCourseExamDate.Visible = false;

			/*  visible columns in grid4
				3  CourseName
				4  Units
				5  Group
				7  StaffName
				9  TechName
				17 Room1Name
				25 Room2Name
				26 Capacity
				27 ExamDate
				28 Note
			*/
			//set required menus to visible
			switch (col)
				{
				case 3:
					//CourseName
					MenuAddCourse.Visible = true;
					MenuEditCourse.Visible = true;
					MenuReplaceCourse.Visible = true;
					MenuDelCourse.Visible = true;
					MenuLine1.Visible = true;
					MenuAddGroup1.Visible = true;
					break;
				case 4:
					//Units
					break;
				case 5:
					//Group
					MenuAddGroup.Visible = true;
					MenuEditGroup.Visible = true;
					break;
				case 7:
					//StaffName
					MenuSetStaff.Visible = true;
					MenuDelStaff.Visible = true;
					break;
				case 9:
					//TechName
					MenuSetTech.Visible = true;
					MenuDelTech.Visible = true;
					break;
				case 17:
					//Room1
					MenuSetClass1.Visible = true;
					MenuDelClass1.Visible = true;
					break;
				case 25:
					//Room2
					MenuSetClass2.Visible = true;
					MenuDelClass2.Visible = true;
					break;
				case 26:
					//Capacity
					MenuNumberOfStudents.Visible = true;
					break;
				case 27:
					//ExamDate
					MenuShowCourseNote.Visible = true;
					MenuShowCourseExamDate.Visible = true;
					break;
				case 28:
					//Note
					MenuShowCourseNote.Visible = true;
					MenuShowCourseExamDate.Visible = true;
					break;
				default:
					//same as CourseName(=3)
					MenuAddCourse.Visible = true;
					MenuEditCourse.Visible = true;
					MenuReplaceCourse.Visible = true;
					MenuDelCourse.Visible = true;
					MenuLine1.Visible = true;
					MenuAddGroup1.Visible = true;
					break;
				}
			}
		private void FeedGridWeek ()
			{
			int rx = Grid4.CurrentRow.Index;
			//Grid4.Col  10=SAT 15=THR
			for (int intTime = 0; intTime <= 7; intTime++)
				{
				for (int intday = 0; intday <= 5; intday++)
					{
					if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [rx] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [rx] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
						{
						TermProg.tblThisCourseTime.Rows [intday] [intTime] = "1";
						}
					else
						{
						TermProg.tblThisCourseTime.Rows [intday] [intTime] = "0";
						}
					}
				}
			}
		private void AddCourse ()
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			if (Grid4.RowCount < 1)
				return;
			Department.Id = Conversions.ToLong (ComboBox1.GetItemText (ComboBox1.SelectedValue));
			Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblEntries"].Rows [ListBox1.SelectedIndex] [2]);
			My.MyProject.Forms.ChooseCourse.ShowDialog ();
			if (string.IsNullOrEmpty (Course.Name))
				{
				return;
				}
			else
				{
				DialogResult myansw = MessageBox.Show ("اين درس به برنامه ترم اضافه شود؟", Course.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				if (myansw == DialogResult.No)
					return;
				}
			Entry.Id = Conversions.ToLong (ListBox1.SelectedValue); // This Entry of This BioProg
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue);  // This Term
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@ent, @term, @courseid, 1)";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@ent", Conversion.Val (Entry.Id));
					cmd.Parameters.AddWithValue ("@term", Conversion.Val (Term.Id));
					cmd.Parameters.AddWithValue ("@courseid", Conversion.Val (Course.Id));
					cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				NxDb.LOG ("crs-" + Course.Number.ToString () + ",ent " + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name);
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		private void EditCourse ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				return;
			Department.Id = Conversions.ToLong (ComboBox1.GetItemText (ComboBox1.SelectedValue));
			Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblEntries"].Rows [ListBox1.SelectedIndex] [2]);
			Course.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [1]);
			My.MyProject.Forms.ChooseCourse.ShowDialog ();
			if (string.IsNullOrEmpty (Course.Name))
				return;
			DialogResult myansw = (DialogResult) MessageBox.Show ("در برنامه اين ترم، درس \n\n" + Course.Name + "\n\nجايگزين درس فعلي شود؟", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (myansw == DialogResult.No)
				return;
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [3] = Course.Name;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Course_ID = @courseid WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@courseid", Conversion.Val (Course.Id));
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			NxDb.LOG ("crs?" + Course.Number.ToString () + ",ent " + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name);
			}
		private void ReplaceCourse ()
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			string newTerm = ListBox2.Text;
			TermProg.Caption = "Terms";
			My.MyProject.Forms.ChooseTerm.ShowDialog ();
			if (Term.Id == 0L)
				{
				MessageBox.Show ("انصراف از انتقال درس", "نکسترم", MessageBoxButtons.OK);
				}
			else
				{
				DialogResult myansw = (DialogResult) MessageBox.Show (" آيا از جابجا کردن اين درس به ترم " + Term.Name + "  مطمئن هستيد؟ ", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (myansw == DialogResult.Yes)
					{
					try
						{
						using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
							{
							NxDb.strSQL = "UPDATE TermProgs SET Term_ID=@term WHERE ID=@id";
							CnnSS.Open ();
							var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
							cmd.CommandType = CommandType.Text;
							cmd.Parameters.AddWithValue ("@term", Conversion.Val (Term.Id));
							cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
							int i = cmd.ExecuteNonQuery ();
							CnnSS.Close ();
							}
						NxDb.LOG ("crs.trm?:" + Course.Number.ToString () + ",ent " + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name);
						}
					catch (Exception ex)
						{
						MessageBox.Show ("Replacing Course : Error", "Err", MessageBoxButtons.OK);
						}
					}
				else
					{
					return;
					}
				}
			}
		private void DelCourse ()
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			var myansw = MessageBox.Show ("آيا از حذف اين درس مطمئن هستيد؟", "NexTerm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (myansw == DialogResult.No)
				return;
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "DELETE FROM TermProgs WHERE ID=@id";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@id", Grid4.Rows [r].Cells [0].Value);
					cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				NxDb.LOG ("crs-" + Course.Number.ToString () + ",ent " + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name);
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		private void AddGroup ()
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			int intGroup;
			Entry.Id = Conversions.ToLong (ListBox1.SelectedValue); // This Entry of This BioProg
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue); // This Term
			intGroup = Conversions.ToInteger (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [5]);
			intGroup = intGroup + 1;
			Course.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [1]);
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@ent, @term, @course, @grp)";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@ent", Conversion.Val (Entry.Id));
					cmd.Parameters.AddWithValue ("@term", Conversion.Val (Term.Id));
					cmd.Parameters.AddWithValue ("@course", Conversion.Val (Course.Id));
					cmd.Parameters.AddWithValue ("@grp", Conversion.Val (intGroup));
					cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				NxDb.LOG ("crs+" + Course.Number.ToString () + ",ent " + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name);
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		private void EditGroup ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			int grp = Conversions.ToInteger (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [5]);
			grp = (int) Math.Round (Conversion.Val (Interaction.InputBox ("شماره گروه", "NexTerm", grp.ToString ())));
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [5] = grp;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET [Group] = @Grp WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@Grp", grp);
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void SetStaff ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
			My.MyProject.Forms.ChooseStaff.ShowDialog ();
			DialogResult z;
			if (string.IsNullOrEmpty (Staff.Name))
				{
				z = MessageBox.Show ("نام استاد براي اين درس حذف شود؟", "Confirm:", MessageBoxButtons.YesNo);
				if (z == DialogResult.No)
					return;
				}
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [7] = Staff.Name;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Staff_ID = @staffid WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@staffid", Conversion.Val (Staff.Id));
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void DelStaff ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				return;
			DialogResult z = MessageBox.Show ("نام استاد براي اين درس حذف شود؟", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
			if (z == DialogResult.No)
				return;
			Staff.Name = "";
			Staff.Id = 0;
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [7] = "";
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Staff_ID = 0 WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void SetTech ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			My.MyProject.Forms.ChooseTech.ShowDialog ();
			if (string.IsNullOrEmpty (Tech.Name))
				{
				DialogResult z = MessageBox.Show ("نام کارشناس براي اين درس حذف شود؟", "Confirm:", MessageBoxButtons.YesNo);
				if (z == DialogResult.No)
					return;
				}
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [9] = Tech.Name;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Tech_ID = @techid WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@techid", Conversion.Val (Tech.Id));
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void DelTech ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				return;
			DialogResult z = MessageBox.Show ("نام کارشناس براي اين درس حذف شود؟", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
			if (z == DialogResult.No)
				return;
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [9] = "";
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Tech_ID = 0 WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void SetClass1 ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x4) == 0x0)
				{
				return;
				}
			try
				{
				Term.Id = Convert.ToInt64 (ListBox2.SelectedValue);
				Room.Id = Convert.ToInt64 (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [c - 1]); // IDs: 16=Room1, 24=Room2 
				TermProg.GridRowId = Grid4.CurrentRow.Index;
				TermProg.Roomx = 1;
				My.MyProject.Forms.ChooseClass.ShowDialog ();
				if (string.IsNullOrEmpty (Room.Name))
					return;
				}
			catch (Exception ex)
				{
				MessageBox.Show ("Error: Try Again!\n" + ex.ToString (), "NexTerm", MessageBoxButtons.OK);
				}
			//save returned data
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [c] = Room.Name;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET SAT1=@sat1, SUN1=@sun1, MON1=@mon1, TUE1=@tue1, WED1=@wed1, THR1=@thr1, Room1 = @room1 WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@sat1", Conversion.Val (TermProg.Class1DayData [0]));
				cmd.Parameters.AddWithValue ("@sun1", Conversion.Val (TermProg.Class1DayData [1]));
				cmd.Parameters.AddWithValue ("@mon1", Conversion.Val (TermProg.Class1DayData [2]));
				cmd.Parameters.AddWithValue ("@tue1", Conversion.Val (TermProg.Class1DayData [3]));
				cmd.Parameters.AddWithValue ("@wed1", Conversion.Val (TermProg.Class1DayData [4]));
				cmd.Parameters.AddWithValue ("@thr1", Conversion.Val (TermProg.Class1DayData [5]));
				cmd.Parameters.AddWithValue ("@room1", Conversion.Val (Room.Id));
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void DelClass1 ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			DialogResult z = MessageBox.Show ("کلاس اين درس حذف شود؟", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
			if (z == DialogResult.No)
				return;
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "UPDATE TermProgs SET Room1=0 WHERE ID = @ID";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			ListBox2_Click (null, null);
			}
		private void SetClass2 ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x4) == 0x0)
				{
				return;
				}
			try
				{
				Term.Id = Convert.ToInt64 (ListBox2.SelectedValue);
				Room.Id = Convert.ToInt64 (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [c - 1]); // IDs: 16=Room1, 24=Room2 
				TermProg.GridRowId = Grid4.CurrentRow.Index;
				TermProg.Roomx = 2;
				My.MyProject.Forms.ChooseClass.ShowDialog ();
				if (string.IsNullOrEmpty (Room.Name))
					return;
				}
			catch (Exception ex)
				{
				MessageBox.Show ("Error: Try Again!\n" + ex.ToString (), "NexTerm", MessageBoxButtons.OK);
				}
			//save returned data
			NxDb.DS.Tables ["tblTermProgs"].Rows [r] [c] = Room.Name;
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET SAT2=@sat2, SUN2=@sun2, MON2=@mon2, TUE2=@tue2, WED2=@wed2, THR2=@thr2, Room2 = @room2 WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@sat2", Conversion.Val (TermProg.Class2DayData [0]));
				cmd.Parameters.AddWithValue ("@sun2", Conversion.Val (TermProg.Class2DayData [1]));
				cmd.Parameters.AddWithValue ("@mon2", Conversion.Val (TermProg.Class2DayData [2]));
				cmd.Parameters.AddWithValue ("@tue2", Conversion.Val (TermProg.Class2DayData [3]));
				cmd.Parameters.AddWithValue ("@wed2", Conversion.Val (TermProg.Class2DayData [4]));
				cmd.Parameters.AddWithValue ("@thr2", Conversion.Val (TermProg.Class2DayData [5]));
				cmd.Parameters.AddWithValue ("@room2", Conversion.Val (Room.Id));
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void DelClass2 ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			DialogResult z = MessageBox.Show ("کلاس اين درس حذف شود؟", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
			if (z == DialogResult.No)
				return;
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "UPDATE TermProgs SET Room2=0 WHERE ID = @ID";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			ListBox2_Click (null, null);
			}
		private void SetCapacity ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				return;
			var cp = default (int);
			try
				{
				cp = Conversions.ToInteger (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [26]);
				}
			catch
				{
				cp = 0;
				}
			finally
				{
				cp = (int) Math.Round (Conversion.Val (Interaction.InputBox ("Change Capacity > ", "NexTerm", cp.ToString ())));
				NxDb.DS.Tables ["tblTermProgs"].Rows [r] [26] = cp;
				}
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Capacity = @Capa WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@Capa", cp);
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void SetNote ()
			{
			if (Grid4.RowCount < 1)
				return;
			int r = Grid4.SelectedCells [0].RowIndex;    // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0 | c < 1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			string strNote = "";
			try
				{
				strNote = Conversions.ToString (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [28]);
				}
			catch
				{
				strNote = "";
				}
			finally
				{
				strNote = Interaction.InputBox ("يادداشت ", "نکسترم", strNote.ToString ());
				NxDb.DS.Tables ["tblTermProgs"].Rows [r] [28] = strNote;
				}
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				NxDb.strSQL = "UPDATE TermProgs SET Notes = @notes WHERE ID = @ID";
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue ("@notes", strNote);
				cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTermProgs"].Rows [r] [0].ToString ());
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void SetExamDate ()
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				return;
				}
			int r = Grid4.SelectedCells [0].RowIndex; // count from 0
			int c = Grid4.SelectedCells [0].ColumnIndex; // count from 0
			if (r < 0)
				return;
			if (Grid4 [c, r].Value is null || Grid4 [c, r].Value is DBNull)
				return;
			try
				{
				Entry.Id = Conversions.ToLong (ListBox1.SelectedValue);
				Entry.Name = ListBox1.Text;
				Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
				Staff.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [6]);
				Staff.Name = Conversions.ToString (Grid4 [7, r].Value);
				TermProg.ExamDateTime = Strings.Trim (txtExamDate.Text);
				Course.Name = Conversions.ToString (NxDb.DS.Tables ["tblTermProgs"].Rows [r] [3]);
				}
			catch (Exception ex)
				{
				// MsgBox(ex.ToString)
				return;
				}
			My.MyProject.Forms.frmDateTime.ShowDialog ();

			ListBox2CLICKED ();
			}
		//Grid Time
		private void GridTime_ShowCourse ()
			{
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					GridTime [c, r].Value = "";
				}
			GridTime.Visible = true;
			lblCourse.Visible = true;
			lblCourse.Text = "زمان بندي درس " + Course.Name;
			txtExamDate.Visible = true;
			lblExamDate.Visible = true;
			lblClss1.Visible = true;
			lblClss2.Visible = true;
			int ri = Grid4.SelectedCells [0].RowIndex;
			if (NxDb.DS.Tables ["tblTermProgs"].Rows [ri] [27] is null || NxDb.DS.Tables ["tblTermProgs"].Rows [ri] [27] is DBNull)
				{
				txtExamDate.Text = "";
				}
			else
				{
				txtExamDate.Text = Conversions.ToString (NxDb.DS.Tables ["tblTermProgs"].Rows [ri] [27]);
				}
			MenuGridTimeReport.Enabled = false;
			PopMenu_SaveWeek.Enabled = true;
			int rx = Grid4.CurrentRow.Index;
			// Grid4.Col  10=SAT 15=THR
			for (int intTime = 0; intTime <= 7; intTime++)
				{
				for (int intday = 0; intday <= 5; intday++)
					{
					if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [rx] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [rx] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
						{
						GridTime [intTime + 1, intday].Value = TermProg.Time [intTime];
						}
					}
				}
			GridWeek.Visible = true;
			HilightGridTime ();
			}
		private void GridTime_ShowStaff ()
			{
			// Clear the GridTime
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					{
					GridTime [c, r].Value = "";
					GridTime [c, r].Style.ForeColor = Color.Black;
					GridTime [c, r].Style.BackColor = Color.White;
					}
				}
			GridTime.Visible = true;
			lblCourse.Visible = true;
			lblCourse.Text = "برنامه هفتگي استاد " + Staff.Name;
			txtExamDate.Visible = false;
			lblExamDate.Visible = false;
			lblClss1.Visible = false;
			lblClss2.Visible = false;
			MenuGridTimeReport.Enabled = true;
			PopMenu_SaveWeek.Enabled = false;
			NxDb.DS.Tables ["tblAllProgs"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
				CnnSS.Close ();
				}
			Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
			string strTadakhol = "";
			bool TadakholExists = false;
            strTadakhol += "<center>";
            strTadakhol += "<div class= \"table-responsive col-md-4\">";
            strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
			strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th></tr>";
			for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
				{
				for (int intDay = 0; intDay <= 5; intDay++) // each day
					{
					for (int intThisStaff = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo; intThisStaff++)
						{
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
							{
							TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
							GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
							if (TermProg.TimeFlag [intDay, intTime] > 1)
								{
								strTadakhol = Conversions.ToString (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [3] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [5] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [29] + "</td></tr>\n");
								TadakholExists = true;
								}
							}
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
							{
							TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
							GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
							if (TermProg.TimeFlag [intDay, intTime] > 1)
								{
								strTadakhol = Conversions.ToString (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [3] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [5] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [29] + "</td></tr>\n");
								TadakholExists = true;
								}
							}
						}
					}
				}
            strTadakhol += "</table>";
            strTadakhol += "</div>";
            strTadakhol += "</center>";
			// =======================================================================OPEN Staff()
			FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_Staff.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>برنامه استاد</title>");
			FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
			FileSystem.PrintLine (1, "</head>");

			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h1 style='color:red; text-align: center'>", Staff.Name, "</h1>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><hr>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
			if (TadakholExists == true)
				{
				FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
				FileSystem.PrintLine (1, strTadakhol);
				FileSystem.PrintLine (1, "<br>");
				}
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه استاد</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			FileSystem.PrintLine (1, "<tr><th>شماره</th>");
			FileSystem.PrintLine (1, "<th>گ</th>");
			FileSystem.PrintLine (1, "<th>نام درس</th>");
			FileSystem.PrintLine (1, "<th>واحد</th>");
			FileSystem.PrintLine (1, "<th>نام مدرس</th>");
			FileSystem.PrintLine (1, "<th>کارشناس</th>");
			FileSystem.PrintLine (1, "<th>ش</th>");
			FileSystem.PrintLine (1, "<th>ي</th>");
			FileSystem.PrintLine (1, "<th>د</th>");
			FileSystem.PrintLine (1, "<th>س</th>");
			FileSystem.PrintLine (1, "<th>چ</th>");
			FileSystem.PrintLine (1, "<th>پ</th>");
			FileSystem.PrintLine (1, "<th>امتحان</th>");
			FileSystem.PrintLine (1, "<th>کلاس1</th>");
			FileSystem.PrintLine (1, "<th>کلاس2</th>");
			FileSystem.PrintLine (1, "<th>ظرفيت</th>");
			FileSystem.PrintLine (1, "<th>يادداشت</th>");
			FileSystem.PrintLine (1, "<th>ورودي</th></tr>");
			for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo1; i++)
				{
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   // 2 :CourseNumber
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   // 5 :Group
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   // 3 :CourseName
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   // 4 :Unit
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   // 7 :Staff
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9], "</td>");   // 9 :Tech
				for (int intday = 0; intday <= 5; intday++)
					{
					string x = "";
					for (int intTime = 0; intTime <= 7; intTime++)
						{
						if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
							{
							x = x + TermProg.Time [intTime] + "<br>"; // Time
							}
						}
					FileSystem.PrintLine (1, "<td>", x, "</td>"); // Time
					}
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "</td>"); // 27:Exam
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "</td>"); // 17:Class1
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "</td>"); // 25:Class2
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [26], "</td>"); // 26:Capacity
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>"); // 28:Notes
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "</td>"); // 29:Ent
				FileSystem.PrintLine (1, "</tr>");
				}
			FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			// table: free times
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
			DrawFreeTimeTable ();
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
			// table of Exams dates for Staff
			NxDb.DS.Tables ["tblTermExams"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY ExamDate", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
				CnnSS.Close ();
				}
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه امتحانات</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			FileSystem.PrintLine (1, "<tr><th>تاريخ</th>");
			FileSystem.PrintLine (1, "<th>درس</th>");
			FileSystem.PrintLine (1, "<th>ورودي</th></tr>");
			for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo2; i++)
				{
				FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [1], "</td>");  // 1 :Exam
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [2], "</td>");      // 2 :Course
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [7], "</td></tr>"); // 7 :Entry string
				}
			FileSystem.PrintLine (1, "</table>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			//footer
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					{
					if (Conversion.Val (GridTime [c, r].Value) > 1d)
						{
						GridTime [c, r].Style.ForeColor = Color.Red;
						}
					}
				}
			HilightGridTime ();
			}
		private void GridTime_ShowTech ()
			{
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					{
					GridTime [c, r].Value = "";
					GridTime [c, r].Style.ForeColor = Color.Black;
					GridTime [c, r].Style.BackColor = Color.White;
					}
				}
			GridTime.Visible = true;
			lblCourse.Visible = true;
			lblCourse.Text = "برنامه هفتگي کارشناس " + Tech.Name;
			txtExamDate.Visible = false;
			lblExamDate.Visible = false;
			lblClss1.Visible = false;
			lblClss2.Visible = false;
			MenuGridTimeReport.Enabled = true;
			PopMenu_SaveWeek.Enabled = false;
			NxDb.DS.Tables ["tblAllProgs"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Tech_ID = " + Tech.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
				CnnSS.Close ();
				}
			Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
			string strTadakhol = "";
			bool TadakholExists = false;
            strTadakhol += "<center>";
            strTadakhol += "<div class= \"table-responsive col-md-4\">";
            strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
			strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>ورودي</th></tr>";
			for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
				{
				for (int intDay = 0; intDay <= 5; intDay++)
					{
					for (int intThisStaff = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo; intThisStaff++)
						{
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
							{
							TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
							GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
							if (TermProg.TimeFlag [intDay, intTime] > 1)
								{
								strTadakhol = Conversions.ToString (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [3] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [29] + "</td></tr>\n");
								TadakholExists = true;
								}
							}
						if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
							{
							TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
							GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
							if (TermProg.TimeFlag [intDay, intTime] > 1)
								{
								strTadakhol = Conversions.ToString (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [3] + "</td><td>" + NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [29] + "</td></tr>\n");
								TadakholExists = true;
								}
							}
						}
					}
				}
            strTadakhol += "</table>";
            strTadakhol += "</div>";
            strTadakhol += "</center>";
			// =======================================================================OPEN Staff()
			FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_Tech.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>برنامه کارشناس</title>");
			FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
			FileSystem.PrintLine (1, "</head>");
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h1 style='color:red; text-align: center'>", Tech.Name, "</h1>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><hr>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
			if (TadakholExists == true)
				{
				FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
				FileSystem.PrintLine (1, strTadakhol);
				FileSystem.PrintLine (1, "<br>");
				}
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه استاد</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			FileSystem.PrintLine (1, "<tr><th>شماره</th>");
			FileSystem.PrintLine (1, "<th>گ</th>");
			FileSystem.PrintLine (1, "<th>نام درس</th>");
			FileSystem.PrintLine (1, "<th>واحد</th>");
			FileSystem.PrintLine (1, "<th>نام مدرس</th>");
			FileSystem.PrintLine (1, "<th>کارشناس</th>");
			FileSystem.PrintLine (1, "<th>ش</th>");
			FileSystem.PrintLine (1, "<th>ي</th>");
			FileSystem.PrintLine (1, "<th>د</th>");
			FileSystem.PrintLine (1, "<th>س</th>");
			FileSystem.PrintLine (1, "<th>چ</th>");
			FileSystem.PrintLine (1, "<th>پ</th>");
			FileSystem.PrintLine (1, "<th>امتحان</th>");
			FileSystem.PrintLine (1, "<th>کلاس1</th>");
			FileSystem.PrintLine (1, "<th>کلاس2</th>");
			FileSystem.PrintLine (1, "<th>ظرفيت</th>");
			FileSystem.PrintLine (1, "<th>يادداشت</th>");
			FileSystem.PrintLine (1, "<th>ورودي</th></tr>");
			for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo1; i++)
				{
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   // 2 :CourseNumber
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   // 5 :Group
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   // 3 :CourseName
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   // 4 :Unit
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   // 7 :Staff
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9], "</td>");   // 9 :Tech
				for (int intday = 0; intday <= 5; intday++)
					{
					string x = "";
					for (int intTime = 0; intTime <= 7; intTime++)
						{
						if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
							{
							x = x + TermProg.Time [intTime] + "<br>"; // Time
							}
						}
					FileSystem.PrintLine (1, "<td>", x, "</td>"); // Time
					}
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "</td>"); // 27:Exam
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "</td>"); // 17:Class1
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "</td>"); // 25:Class2
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [26], "</td>"); // 26:Capacity
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>"); // 28:Notes
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "</td>"); // 29:Ent
				FileSystem.PrintLine (1, "</tr>");
				}
			FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			// table: free times
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
			DrawFreeTimeTable ();
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
			//footer
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					{
					if (Conversion.Val (GridTime [c, r].Value) > 1d)
						{
						GridTime [c, r].Style.ForeColor = Color.Red;
						}
					}
				}
			HilightGridTime ();
			}
		private void GridTime_ShowRoom ()
			{
			for (int c = 1; c <= 8; c++)
				{
				for (int r = 0; r <= 5; r++)
					{
					GridTime [c, r].Value = "";
					GridTime [c, r].Style.ForeColor = Color.Black;
					GridTime [c, r].Style.BackColor = Color.White;
					}
				}
			GridTime.Visible = true;
			lblCourse.Visible = true;
			lblCourse.Text = "برنامه هفتگي " + Room.Name;
			txtExamDate.Visible = false;
			lblExamDate.Visible = false;
			lblClss1.Visible = false;
			lblClss2.Visible = false;
			MenuGridTimeReport.Enabled = true;
			PopMenu_SaveWeek.Enabled = false;
			NxDb.DS.Tables ["tblAllProgs"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE ((Term_ID = " + Term.Id.ToString () + ") AND ((Room1 = " + Room.Id.ToString () + ") OR (Room2 = " + Room.Id.ToString () + "))) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
				CnnSS.Close ();
				}
			Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
			string strTadakhol = "";
			bool TadakholExists = false;
            strTadakhol += "<center>";
            strTadakhol += "<div class= \"table-responsive col-md-4\">";
            strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
			strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th><th>استاد</th></tr>";
			try
				{
				for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
					{
					for (int intDay = 0; intDay <= 5; intDay++)
						{
						for (int intThisRoom = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisRoom <= loopTo; intThisRoom++)
							{
							if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [16], Room.Id, false))))
								{
								TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
								GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
								if (TermProg.TimeFlag [intDay, intTime] > 1)
									{
									strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [29]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [7]), "</td></tr>"), Constants.vbCrLf));
									TadakholExists = true;
									}
								}
							// If IsDBNull(DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24)) Then DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24) = 0
							if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Conversion.Val (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [24]) == Room.Id)))
								{
								TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
								GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
								if (TermProg.TimeFlag [intDay, intTime] > 1)
									{
									strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [29]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [7]), "</td></tr>"), Constants.vbCrLf));
									TadakholExists = true;
									}
								}
							}
						}
					}
				}
			catch (Exception ex)
				{
				//MsgBox(ex.ToString)
				}
            strTadakhol += "</table>";
            strTadakhol += "</div>";
            strTadakhol += "</center>";
			//OPEN Staff()
			FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_class.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>برنامه کلاس</title>");
			FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
			FileSystem.PrintLine (1, "</head>");
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h1 style='color:red; text-align: center'>", Room.Name, "</h1>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><hr>");
			if (TadakholExists == true)
				{
				FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
				FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
				FileSystem.PrintLine (1, strTadakhol);
				FileSystem.PrintLine (1, "<br>");
				}
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه کلاس</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
			FileSystem.PrintLine (1, "<tr><th>شماره</th>");
			FileSystem.PrintLine (1, "<th>گ</th>");
			FileSystem.PrintLine (1, "<th>نام درس</th>");
			FileSystem.PrintLine (1, "<th>واحد</th>");
			FileSystem.PrintLine (1, "<th>نام مدرس</th>");
			FileSystem.PrintLine (1, "<th>کارشناس</th>");
			FileSystem.PrintLine (1, "<th>ش</th>");
			FileSystem.PrintLine (1, "<th>ي</th>");
			FileSystem.PrintLine (1, "<th>د</th>");
			FileSystem.PrintLine (1, "<th>س</th>");
			FileSystem.PrintLine (1, "<th>چ</th>");
			FileSystem.PrintLine (1, "<th>پ</th>");
			FileSystem.PrintLine (1, "<th>امتحان</th>");
			FileSystem.PrintLine (1, "<th>کلاس1</th>");
			FileSystem.PrintLine (1, "<th>کلاس2</th>");
			FileSystem.PrintLine (1, "<th>ظرفيت</th>");
			FileSystem.PrintLine (1, "<th>يادداشت</th>");
			FileSystem.PrintLine (1, "<th>ورودي</th></tr>");
			for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo1; i++)
				{
				FileSystem.PrintLine (1, "<tr>");
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   // 2 :CourseNumber
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   // 5 :Group
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   // 3 :CourseName
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   // 4 :Unit
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   // 7 :Staff
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9], "</td>");   // 9 :Tech
				for (int intday = 0; intday <= 5; intday++)
					{
					string x = "";
					for (int intTime = 0; intTime <= 7; intTime++)
						{
						if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
							{
							x = x + TermProg.Time [intTime] + "<br>"; // Time
							}
						}
					FileSystem.PrintLine (1, "<td>", x, "</td>"); // Time
					}
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "</td>"); // 25:Exam
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "</td>"); // 17:Class1
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "</td>"); // 25:Class2
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [26], "</td>"); // 26:Capacity
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>"); // 28:Notes
				FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "</td>"); // 29:Ent
				FileSystem.PrintLine (1, "</tr>");
				}
			FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			// table: free times
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
			DrawFreeTimeTable ();
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
			//footer
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			for (int intTime = 1; intTime <= 8; intTime++)
				{
				for (int intDay = 0; intDay <= 5; intDay++)
					{
					if (Conversion.Val (GridTime [intTime, intDay].Value) > 1d)
						GridTime [intTime, intDay].Style.ForeColor = Color.Red;
					}
				}
			HilightGridTime ();
			}
		private void HilightGridTime ()
			{
			switch (TermProg.Caption)
				{
				case "Room":
						{
						for (int intTime = 0; intTime <= 7; intTime++)
							{
							for (int intday = 0; intday <= 5; intday++)
								{
								GridTime [intTime + 1, intday].Style.BackColor = Color.White;
								switch (TermProg.Roomx)
									{
									case 1:
											{
											if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [Grid4.CurrentRow.Index] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
												GridTime [intTime + 1, intday].Style.BackColor = Color.LightCyan;
											break;
											}
									case 2:
											{
											if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [Grid4.CurrentRow.Index] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
												GridTime [intTime + 1, intday].Style.BackColor = Color.MistyRose;
											break;
											}
									}
								}
							}

						break;
						}

				default:
						{
						for (int intTime = 0; intTime <= 7; intTime++)
							{
							for (int intday = 0; intday <= 5; intday++)
								{
								GridTime [intTime + 1, intday].Style.BackColor = Color.White;
								if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [Grid4.CurrentRow.Index] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
									GridTime [intTime + 1, intday].Style.BackColor = Color.LightCyan;
								if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblTermProgs"].Rows [Grid4.CurrentRow.Index] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
									GridTime [intTime + 1, intday].Style.BackColor = Color.MistyRose;
								}
							}

						break;
						}
				}
			GridTime.CurrentCell = GridTime [0, 0];
			}
		private void MenuGridTimeReport_Click (object sender, EventArgs e)
			{
			// OPEN REPORT inHTML
			switch (TermProg.Caption)
				{
				case "Staff":
						{
						Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_Staff.html");
						break;
						}
				case "Tech":
						{
						Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_Tech.html");
						break;
						}
				case "Room":
						{
						Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_Class.html");
						break;
						}
				}
			}
		private void GridTime_Hide ()
			{
			GridTime.Visible = false;
			lblCourse.Visible = false;
			txtExamDate.Visible = false;
			lblExamDate.Visible = false;
			lblClss1.Visible = false;
			lblClss2.Visible = false;
			GridWeek.Visible = false;
			}
		private void GridTime_CellClick (object sender, DataGridViewCellEventArgs e)
			{
			lblExtraUnitsError.Visible = false;
			try
				{
				Entry.Name = ListBox1.Text;
				Term.Name = ListBox2.Text;
				int r = GridTime.CurrentCell.RowIndex;    // count from 0
				int c = GridTime.CurrentCell.ColumnIndex; // count from 0
				switch (Grid4.CurrentCell.ColumnIndex)
					{
					case 17:
							{
							TermProg.Roomx = 1;
							break;
							}
					case 25:
							{
							TermProg.Roomx = 2;
							break;
							}
					}
				if (r < 0 | c < 0)
					return;
				//
				switch (TermProg.Caption)
					{
					case "Course": //course
							{
							if ((User.ACCs & 0x10) == 0x0)
								{
								return;
								}
							if (GridTime [c, r].Value.ToString () == "")
								{
								switch (c)
									{
									case 1:
											{
											GridTime [c, r].Value = "08:30";
											break;
											}
									case 2:
											{
											GridTime [c, r].Value = "09:30";
											break;
											}
									case 3:
											{
											GridTime [c, r].Value = "10:30";
											break;
											}
									case 4:
											{
											GridTime [c, r].Value = "11:30";
											break;
											}
									case 5:
											{
											GridTime [c, r].Value = "13:30";
											break;
											}
									case 6:
											{
											GridTime [c, r].Value = "14:30";
											break;
											}
									case 7:
											{
											GridTime [c, r].Value = "15:30";
											break;
											}
									case 8:
											{
											GridTime [c, r].Value = "16:30";
											break;
											}
									}
								}
							else if (c != 0)
								{
								GridTime [c, r].Value = "";
								GridTime [c, r].Style.BackColor = Color.White;
								}
							GridTime.CurrentCell = GridTime [0, r];
							break;
							}
					case "Staff": //staff
							{
							try
								{
								string strTadakholMessage = "";
								if (Convert.ToInt32 (GridTime [c, r].Value.ToString ()) > 0)
									{
									for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
										{
										if ((((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10].ToString ())) & (int) (Math.Pow (2d, c - 1))) == (int) Math.Pow (2d, c - 1)) | ((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18].ToString ()) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))))
											{
											strTadakholMessage = strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3].ToString () + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29].ToString () + "\n" + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17].ToString () + "   " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25].ToString () + "\n\n\n";
											}
										}
									MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
									GridTime.CurrentCell = GridTime [0, r];
									}
								}
							catch (Exception ex)
								{
								//MessageBox.Show ("err\n" + ex.ToString ());
								}

							break;
							}
					case "Tech": //tech
							{
							try
								{
								string strTadakholMessage = "";
								if (Conversion.Val (GridTime [c, r].Value) > 0d)
									{
									for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo1; i++)
										{
										if (((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10]) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))) | ((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18]) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))))
											{
											strTadakholMessage = strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3] + "\n استاد: " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7] + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29] + "\n\n\n";
											}
										}
									MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
									GridTime.CurrentCell = GridTime [0, r];
									}
								}
							catch (Exception ex)
								{
								MessageBox.Show ("err");
								}

							break;
							}
					case "Room": //room
							{
							string strTadakholMessage = "";
							if (Conversion.Val (GridTime [c, r].Value) > 0d)
								{
								try
									{
									for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo2; i++)
										{
										//if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [16], Room.Id, false))))
										if (((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10]) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))) & (Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [16]) == Room.Id))
											{
											strTadakholMessage = strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3] + "    استاد: " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7] + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29] + "\n\n";
											}
										if (((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18]) & (int) (Math.Pow (2d, c - 1))) == (int) (Math.Pow (2d, c - 1))) & (Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [24]) == Room.Id))
											{
											strTadakholMessage = strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3] + "    استاد: " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7] + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29] + "\n\n";
											}
										}
									MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
									GridTime.CurrentCell = GridTime [0, r];
									}
								catch (Exception ex)
									{
									MessageBox.Show ("err");
									}
								}

							break;
							}
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		//exam DateTime
		private void lblExamDate_Click (object sender, EventArgs e)
			{
			SetExamDate ();
			}
		private void txtExamDate_Click (object sender, EventArgs e)
			{
			lblExamDate_Click (sender, e);
			}
		//popup menu - TERMS List
		private void Menu_TermsDefault_Set_Click (object sender, EventArgs e)
			{
			if (ListBox2.Items.Count > 0)
				{
				TermProg.DefaultTermId = (int) (ListBox2.SelectedValue);
				}
			}
		private void Menu_TermsDefault_Clear_Click (object sender, EventArgs e)
			{
			TermProg.DefaultTermId = 0;
			}
		//MAIN MENU 1: User
		private void Menu_Userx_Click (object sender, EventArgs e)
			{
			User.ACCs = 0x0;
			//DirectSave2Settings (1);
			//DirectSave2Settings (4);
			Dispose ();
			My.MyProject.Forms.frmCNN.ShowDialog ();
			switch (User.Type)
				{
				case "quit":
						{
						try
							{
							NxDb.LOG ("logout");
							NxDb.CnnSS.Close ();
							NxDb.CnnSS.Dispose ();
							My.MyProject.Forms.frmCNN.Dispose ();
							My.MyProject.Forms.ChooseStaff.Dispose ();
							My.MyProject.Forms.ChooseTech.Dispose ();
							Dispose ();
							Application.Exit ();
							Environment.Exit (0);
							}
						catch
							{
							MessageBox.Show ("Error in Exit module ....");
							}
						break;
						}
				case "UserDeputy":
				case "UserDepartment":
						{
						NxDb.LOG ("usr?");
						ComboBox1.SelectedValue = User.Id;
						break;
						}
				}
			Text = "NexTerm  |  " + User.Type + "  Connected to :  " + NxDb.Server2Connect;
			EnableMenu ();
			ClrForm ();
			GridTime_Hide ();
			}
		private void Menu_ChangePass_Click (object sender, EventArgs e)
			{
			if (User.Type == "UserDeputy" | User.Id == 0) // MsgBox("کاربر دانشکده (ادمين) براي تغيير پسورد به بخش تنظيمات مراجعه کنيد", vbOKOnly, "نکسترم")
				{
				Menu_Settings_Click (sender, e);
				return;
				}
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("قابليت (تغيير کلمه عبور) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
				}
			string strOldPass = "";
			string strNewPass = "";
			string strcheckPass = "";
			strOldPass = Conversions.ToString (NxDb.DS.Tables ["tblDepartments"].Rows [ComboBox1.SelectedIndex] [4]);
			strcheckPass = Interaction.InputBox ("پسورد فعلي را وارد کنيد", "نکسترم", "");
			if ((strcheckPass ?? "") != (strOldPass ?? ""))
				{
				strcheckPass = Interaction.InputBox ("پسورد فعلي را  - بطور صحيح -  وارد کنيد", "توجه:", "");
				if ((strcheckPass ?? "") != (strOldPass ?? ""))
					{
					Menu_Userx_Click (sender, e);
					return;
					}
				}
			else
				{
				strNewPass = Strings.Trim (Interaction.InputBox ("پسورد جديد را وارد کنيد", "تغيير پسورد", ""));
				if (string.IsNullOrEmpty (strNewPass) | (strNewPass ?? "") == (strOldPass ?? ""))
					{
					return;
					}
				else
					{
					strOldPass = strNewPass;
					strNewPass = Strings.Trim (Interaction.InputBox ("پسورد جديد را  ( دوباره )  وارد کنيد", "تغيير پسورد", ""));
					if ((strNewPass ?? "") != (strOldPass ?? ""))
						{
						MessageBox.Show ("تکرار پسورد جديد نادرست بود", "عمليات ناموفق", MessageBoxButtons.OK);
						return;
						}
					NxDb.DS.Tables ["tblDepartments"].Rows [ComboBox1.SelectedIndex] [4] = strNewPass;
					}
				}
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "UPDATE Departments SET DepartmentPass=@deptpass WHERE ID=@id";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@deptpass", strNewPass);
					cmd.Parameters.AddWithValue ("@id", User.Id.ToString ());
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show ("خطا در بروزرساني کلمه عبور", "نکسترم", MessageBoxButtons.OK);
				}
			User.DepartmentPass = strNewPass;
			NxDb.LOG ("usr.pwd?");
			MessageBox.Show ("کلمه عبور تغيير يافت", "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		private void Menu_Settings_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به (تنظيمات) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			if (User.Type == "UserDeputy")
				{
				NxDb.LOG ("settings");
				My.MyProject.Forms.Settings.ShowDialog ();
				EnableMenu ();
				ClrForm ();
				GridTime_Hide ();
				}
			}
		private void Menu_Messenger_Click (object sender, EventArgs e)
			{
			// OPEN notes form (messaging)
			if (User.Type != "UserOfficer")
				My.MyProject.Forms.frmShowNotes.ShowDialog ();
			}
		private void Menu_About_Click (object sender, EventArgs e)
			{
			My.MyProject.Forms.frmAbout.ShowDialog ();
			}
		private void lbl_UserType_DoubleClick (object sender, EventArgs e)
			{
			Menu_Messenger_Click (sender, e);
			}
		private void Menu_Quit_Click (object sender, EventArgs e)
			{
			DoExitNexTerm ();
			}
		//MAIN MENU 2: Resource
		private void Menu_Departments_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به منابع اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			else
				{
				Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
				// MsgBox("before going to Depts: intdept=" & intDept.ToString & " /intUser=" & intUser.ToString)
				Dispose ();
				My.MyProject.Forms.frmDepts.ShowDialog ();
				}
			}
		private void Menu_Courses_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به منابع اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			string i = ListBox1.GetItemText (ListBox1.SelectedValue);
			if (Conversion.Val (i) == 0d)
				return;
			Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblEntries"].Rows [ListBox1.SelectedIndex] [2]);
			TermProg.Caption = "Courses";
			My.MyProject.Forms.frmShowTables.ShowDialog ();
			ClrForm ();
			}
		private void Menu_Classes_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به منابع اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			try
				{
				Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
				for (int c = 0; c <= 7; c++)
					{
					for (int r = 0; r <= 5; r++)
						TermProg.tblThisCourseTime.Rows [r] [c] = "";
					}
				}
			catch
				{
				}
			My.MyProject.Forms.ChooseClass.ShowDialog ();
			ClrForm ();
			}
		private void Menu_Terms_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به منابع اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			TermProg.Caption = "Terms";
			My.MyProject.Forms.ChooseTerm.ShowDialog ();
			ClrForm ();
			}
		private void Menu_Staff_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به منابع اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
			if (ComboBox1.SelectedIndex == -1)
				Department.Id = 0L;
			My.MyProject.Forms.ChooseStaff.ShowDialog ();
			ClrForm ();
			}
		private void Menu_Tech_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("دسترسي به منابع اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			My.MyProject.Forms.ChooseTech.ShowDialog ();
			ClrForm ();
			}
		//MAIN MENU 3: Program
		private void Menu_Templates (object sender, EventArgs e)
			{
			if (ComboBox1.SelectedIndex == -1)
				return;
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("قابليت (طراحي برنامه الگو) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
			Hide ();
			My.MyProject.Forms.Templates.ShowDialog ();
			Show ();
			ClrForm ();
			}
		private void Menu_Delete_Entry_TermProg_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("قابليت (برنامه ريزي) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			if (ListBox1.SelectedIndex == -1)
				return;
			DialogResult myansw = MessageBox.Show ("برنامه آموزشي همه ترم هاي اين ورودي حذف شوند؟", "تاييد کنيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
			if (myansw == DialogResult.No)
				return;
			// Again
			myansw = MessageBox.Show ("برنامه هاي اين ورودي حذف شوند؟  مطمئن هستيد؟", "تاييد کنيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
			if (myansw == DialogResult.No)
				return;
			string myansw2 = Interaction.InputBox ("Type this number: 872345652", "تاييد نهايي", "");
			if (myansw2 != "872345652")
				return;
			Entry.Id = Conversions.ToLong (ListBox1.SelectedValue);
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "DELETE From TermProgs WHERE Entry_ID = @id";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@id", Entry.Id.ToString ());
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				MessageBox.Show ("برنامه تمامي ترم هاي ورودي" + Constants.vbCrLf + Constants.vbCrLf + Entry.Name + Constants.vbCrLf + Constants.vbCrLf + "حذف شدند" + Constants.vbCrLf + Constants.vbCrLf + "بااستفاده از برنامه هاي ترميک مي توانيد اين ورودي را مجددا برنامه ريز کنيد", "NexTerm", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				NxDb.LOG ("entPrg-, ent" + Strings.Mid (Entry.Name, 1, 5));
				ListBox1_Click (sender, e);
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		private void Menu_ReProgram_ThisEnteryTerm_inclStaff_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("قابليت (برنامه ريزي) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			if (ListBox2.SelectedIndex == -1)
				return;
			if (Grid4.RowCount < 1)
				return;
			DialogResult myansw = MessageBox.Show (" برنامه ريزي درس هاي اين ترم براي ورودي " + Constants.vbCrLf + Constants.vbCrLf + Entry.Name + Constants.vbCrLf + Constants.vbCrLf + "از نو انجام شود؟", "Term : " + Term.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
			if (myansw == DialogResult.No)
				return;
			// Agian
			myansw = MessageBox.Show (" برنامه ريزي دروس اين ترم براي  " + Constants.vbCrLf + Constants.vbCrLf + Entry.Name + Constants.vbCrLf + Constants.vbCrLf + "پاک شود؟", "Term : " + Term.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
			if (myansw == DialogResult.No)
				return;
			string myansw2 = Interaction.InputBox ("Type this number: 872345652", "تاييد نهايي", "");
			if (myansw2 != "872345652")
				return;
			Entry.Id = Conversions.ToLong (ListBox1.SelectedValue);
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "UPDATE TermProgs SET Staff_ID=0, Tech_ID=0, SAT1=0, SUN1=0, MON1=0, TUE1=0, WED1=0, THR1=0, Room1=0, SAT2=0, SUN2=0, MON2=0, TUE2=0, WED2=0, THR2=0, Room2=0, Capacity=0, ExamDate='', Notes='' WHERE Entry_ID= @entryid AND Term_ID=@termid";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@entryid", Conversion.Val (Entry.Id));
					cmd.Parameters.AddWithValue ("@termid", Conversion.Val (Term.Id));
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				NxDb.LOG ("trmPrg.clr,ent" + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name.ToString ());
				ListBox2_Click (sender, e); //refresh GRID4
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		private void Menu_ReProgram_ThisEnteryTerm_Click (object sender, EventArgs e)
			{
			if ((User.ACCs & 0x10) == 0x0)
				{
				MessageBox.Show ("قابليت (برنامه ريزي) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
				return;
				}
			if (ListBox2.SelectedIndex == -1)
				return;
			if (Grid4.RowCount < 1)
				return;
			DialogResult myansw = (DialogResult) MessageBox.Show (" برنامه ريزي درس هاي اين ترم براي ورودي " + Constants.vbCrLf + Constants.vbCrLf + Entry.Name + Constants.vbCrLf + Constants.vbCrLf + "از نو انجام شود؟", "Term : " + Term.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
			if (myansw == DialogResult.No)
				return;
			// Agian
			myansw = (DialogResult) MessageBox.Show (" برنامه ريزي دروس اين ترم براي  " + Constants.vbCrLf + Constants.vbCrLf + Entry.Name + Constants.vbCrLf + Constants.vbCrLf + "پاک شود؟", "Term : " + Term.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
			if (myansw == DialogResult.No)
				return;
			string myansw2 = Interaction.InputBox ("Type this number: 872345652", "تاييد نهايي", "");
			if (myansw2 != "872345652")
				return;
			Entry.Id = Convert.ToInt64 (ListBox1.SelectedValue);
			Term.Id = Convert.ToInt64 (ListBox2.SelectedValue);
			try
				{
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					NxDb.strSQL = "UPDATE TermProgs SET SAT1=0, SUN1=0, MON1=0, TUE1=0, WED1=0, THR1=0, Room1=0, SAT2=0, SUN2=0, MON2=0, TUE2=0, WED2=0, THR2=0, Room2=0, Capacity=0, ExamDate='', Notes='' WHERE Entry_ID= @entryid AND Term_ID=@termid";
					CnnSS.Open ();
					var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue ("@entryid", Conversion.Val (Entry.Id));
					cmd.Parameters.AddWithValue ("@termid", Conversion.Val (Term.Id));
					int i = cmd.ExecuteNonQuery ();
					CnnSS.Close ();
					}
				NxDb.LOG ("trmPrg.clr,ent" + Strings.Mid (Entry.Name, 1, 5) + ",trm " + Term.Name.ToString ());
				ListBox2_Click (sender, e); // REFRESH GRID4
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		//MAIN MENU 4: Report
		private void Menu_ReviewPrograms_Click (object sender, EventArgs e)
			{
			try
				{
				Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
				}
			catch (Exception ex)
				{
				Department.Id = 0L;
				}
			try
				{
				Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
				}
			catch (Exception ex)
				{
				Term.Id = 0L;
				}
			try
				{
				Entry.Id = Conversions.ToLong (ListBox1.SelectedValue);
				}
			catch (Exception ex)
				{
				Entry.Id = 0L;
				}
			My.MyProject.Forms.frmReviewProgs.ShowDialog ();
			NxDb.LOG ("review.prgs");
			if (ListBox2.Items.Count > 0 & TermProg.DefaultTermId > 0)
				{
				ListBox2.SelectedValue = TermProg.DefaultTermId;
				}
			//reset back the list of Entries to original (for intUser, rather than intDept which is modified in frmReportSettings) 
			ComboBox1_SelectedIndexChanged (sender, e);
			}

		// reports
		//status bits in ReportSettings Register
		// 0: 1    : Remember Settings
		// 1: 2    : Report con Details
		// 2: 4    : Day in Cols:0/Rows:1
		// 3: 8    : Show CourseName
		// 4: 16   : Show CourseNr
		// 5: 32   : Show Group
		// 6: 64   : Show ExamDate
		// 7: 128  : BG
		// 8: 256  : show free times (in: day in col mode)
		private void Menu_ReportEntriesPrograms_Click (object sender, EventArgs e)
			{
			// Report all Entries (in a Dept)
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
			My.MyProject.Forms.frmReportSettings.ShowDialog ();
			if (Nxt.Retval1 == 0)
				return;
			//intDept IS already set in frmREPORTSETTINGS // OR: set as intUser ?
			if (Department.Id == 0L)
				{
				My.MyProject.Forms.ChooseDept.ShowDialog ();
				if (Department.Id == 0L)
					{
					return;
					}
				}
			// READ TABLE
			NxDb.DS.Tables ["tblEntries"].Clear ();
			// READ (from DB) the Entries of the selected Department
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Entries.ID AS EntID, CONCAT(EntYear , ' - ' , ProgramName) As Prog, BioProg_ID FROM ((BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID) INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) WHERE Department_ID =" + Department.Id.ToString () + " AND Active = 1 ORDER BY EntYear, ProgramName", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblEntries");
				CnnSS.Close ();
				}
			FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_entries_All.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			if ((Report.Settings & 0x80) == 0x80) // 128=1000'0000
				{
				FileSystem.PrintLine (1, "<head>");
				FileSystem.PrintLine (1, "<title>برنامه ورودي</title>");
				FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
				FileSystem.PrintLine (1, "</head>");
				}
			else
				{
				FileSystem.PrintLine (1, "<head>");
				FileSystem.PrintLine (1, "<title>برنامه ورودي</title>");
				FileSystem.PrintLine (1, Report.StyleSinBg); // strReportsStyle is defined in Module1
				FileSystem.PrintLine (1, "</head>");
				}
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><p style='color:blue;text-align: center'>" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "</p><hr>");
			for (int ent = 0, loopTo = NxDb.DS.Tables ["tblEntries"].Rows.Count - 1; ent <= loopTo; ent++)
				{
				Entry.Id = Conversions.ToLong (NxDb.DS.Tables ["tblEntries"].Rows [ent] [0]);
				NxDb.DS.Tables ["tblAllProgs"].Clear ();
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Entry_ID = " + Entry.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
					CnnSS.Close ();
					}
				Entry.Name = Conversions.ToString (NxDb.DS.Tables ["tblEntries"].Rows [ent] [1]);
				FileSystem.PrintLine (1, "<h4 style='color:red'>", Entry.Name, "</h4>");
				Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
				string strTadakhol = "";
				bool TadakholExists = false;
                strTadakhol += "<center>";
                strTadakhol += "<div class= \"table-responsive col-md-4\">";
                strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
				strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>استاد</th></tr>";
				for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
					{
					for (int intDay = 0; intDay <= 5; intDay++) // each day
						{
						for (int intThisEntry = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisEntry <= loopTo1; intThisEntry++)
							{
							if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
								{
								TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
								if (TermProg.TimeFlag [intDay, intTime] > 1)
									{
									strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [7]), "</td></tr>"), Constants.vbCrLf));
									TadakholExists = true;
									}
								}
							if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
								{
								TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
								if (TermProg.TimeFlag [intDay, intTime] > 1)
									{
									strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisEntry] [7]), "</td></tr>"), Constants.vbCrLf));
									TadakholExists = true;
									}
								}
							}
						}
					}
                strTadakhol += "</table>";
                strTadakhol += "</div>";
                strTadakhol += "</center>";
				if ((Report.Settings & 0x2) == 0x0)
					goto lblx;
				if ((Report.Settings & 0x200) == 0x200) // flag 512=0010'0000'0000 : show suggestions
					{
					if (TadakholExists == true)
						{
						FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
						FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
						FileSystem.PrintLine (1, strTadakhol);
						FileSystem.PrintLine (1, "<br>");
						}
					}
				//Main Table (Style A / B)
				FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه ورودي</p>");
                FileSystem.PrintLine (1, "<center>");
                FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
                FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse; Text-Align:Center'>");
				if ((Report.Settings & 0x4) == 0x4) //Days of Week in ROWS:1 (for Dr. RoshanZamir)
					{
					FileSystem.PrintLine (1, "<tr><th>روز</th><th>8:30</th><th>9:30</th><th>10:30</th><th>11:30</th><th>13:30</th><th>14:30</th><th>15:30</th><th>16:30</th></tr>");
					for (int intday = 0; intday <= 5; intday++)
						{
						FileSystem.PrintLine (1, "<tr><td>", TermProg.Day [intday], "</td>");                                 // Day of Week
						for (int intTime = 0; intTime <= 7; intTime++)
							{
							FileSystem.PrintLine (1, "<td>");
							for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo2; i++)
								{
								if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
									{
									if ((Report.Settings & 0x8) == 0x8)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");                                                     // 7 :Staff
									if ((Report.Settings & 0x10) == 0x10)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");            // 2 :CourseNumber
									if ((Report.Settings & 0x20) == 0x20)
										FileSystem.PrintLine (1, " گروه ", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "<br>");  // 5 :Group
									if ((Report.Settings & 0x40) == 0x40)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "<br>");           // 27:Exam
									}
								}
							FileSystem.PrintLine (1, "</td>");
							}
						FileSystem.PrintLine (1, "</tr>");
						}
					FileSystem.PrintLine (1, "</table><br>");
                    FileSystem.PrintLine (1,  "</div>");
                    FileSystem.PrintLine (1, "</center>");
                    }
                else //Days of Week in COLS (for Mrs. Valipour)
					{
					FileSystem.PrintLine (1, "<tr><th>شماره</th><th>گ</th><th>نام درس</th><th>واحد</th><th>نام مدرس</th><th>کارشناس</th>");
					FileSystem.PrintLine (1, "<th>ش</th><th>ي</th><th>د</th><th>س</th><th>چ</th><th>پ</th>");
					FileSystem.PrintLine (1, "<th>امتحان</th><th>کلاس1</th><th>کلاس2</th><th>ظرفيت</th><th>يادداشت</th></tr>");
					for (int i = 0, loopTo3 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo3; i++)
						{
						FileSystem.PrintLine (1, "<tr>");
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   // 2 :CourseNumber
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   // 5 :Group
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   // 3 :CourseName
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   // 4 :Unit
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   // 7 :Staff
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9], "</td>");   // 9 :Tech

						for (int intday = 0; intday <= 5; intday++)
							{
							string x = "";
							for (int intTime = 0; intTime <= 7; intTime++)
								{
								if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
									{
									x = x + TermProg.Time [intTime] + "<br>"; // Time
									}
								}
							FileSystem.PrintLine (1, "<td>", x, "</td>"); // Time
							}
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "</td>"); // 27:Exam
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "</td>"); // 17:Class1
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "</td>"); // 25:Class2
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [26], "</td>"); // 26:Capacity
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>"); // 28:Notes
						FileSystem.PrintLine (1, "</tr>");
						}
					FileSystem.PrintLine (1, "</table><br>");
                    FileSystem.PrintLine (1, "</div>");
                    FileSystem.PrintLine (1, "</center>");
                    }
            lblx:
				;

				if ((Report.Settings & 0x100) == 0x100) // =256
					{
					// table: free times
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
					DrawFreeTimeTable ();
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
					}
				if ((Report.Settings & 0x2) == 0x0)
					goto lblx2;
				// table: Exams dates for Staff
				if ((Report.Settings & 0x400) == 0x400)
					{
					NxDb.DS.Tables ["tblTermExams"].Clear ();
					using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
						{
						CnnSS.Open ();
						NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Entry_ID = " + Entry.Id.ToString () + " ORDER BY ExamDate", CnnSS);
						NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
						CnnSS.Close ();
						}
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه امتحانات</p>");
                    FileSystem.PrintLine (1, "<center>");
                    FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
                    FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
					FileSystem.PrintLine (1, "<tr><th>تاريخ</th>");
					FileSystem.PrintLine (1, "<th>درس</th>");
					FileSystem.PrintLine (1, "<th>استاد</th></tr>");
					for (int i = 0, loopTo4 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo4; i++)
						{
						FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [1], "</td>");  // 1 :Exam
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [2], "</td>");      // 2 :Course
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [5], "</td></tr>"); // 5 :StaffName
						}
					FileSystem.PrintLine (1, "</table><br>");
                    FileSystem.PrintLine (1, "</div>");
                    FileSystem.PrintLine (1, "</center>");
					}
			lblx2:
				;
				}
			//footer
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			NxDb.LOG ("rprt.ent.prgs");
			Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_entries_All.html");
			ComboBox1_SelectedIndexChanged (sender, e); //This is important to reset List of Entries back to original (for intUser, rather than intDept which is modified in frmReportSettings) 
			}
		private void Menu_ReportClassPrograms_Click (object sender, EventArgs e)
			{
			// REPORT all CLASSES (in a term)
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
			My.MyProject.Forms.frmReportSettings.ShowDialog ();
			if (Nxt.Retval1 == 0)
				return;
			// READ ROOM TABLE
			NxDb.DS.Tables ["tblRooms"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act FROM Rooms WHERE Active = 1 ORDER BY RoomName", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblRooms");
				CnnSS.Close ();
				}
			FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_class_All.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			if ((Report.Settings & 0x80) == 0x80)
				{
				FileSystem.PrintLine (1, "<head>");
				FileSystem.PrintLine (1, "<title>برنامه کلاس</title>");
				FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
				FileSystem.PrintLine (1, "</head>");
				}
			else
				{
				FileSystem.PrintLine (1, "<head>");
				FileSystem.PrintLine (1, "<title>برنامه کلاس</title>");
				FileSystem.PrintLine (1, Report.StyleSinBg); // strReportsStyle is defined in Module1
				FileSystem.PrintLine (1, "</head>");
				}
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><p style='color:blue;text-align: center'>" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "</p><hr>");
			for (int rm = 0, loopTo = NxDb.DS.Tables ["tblRooms"].Rows.Count - 1; rm <= loopTo; rm++)
				{
				Room.Id = Conversions.ToLong (NxDb.DS.Tables ["tblRooms"].Rows [rm] [0]);
				NxDb.DS.Tables ["tblAllProgs"].Clear ();
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE ((Term_ID = " + Term.Id.ToString () + ") AND ((Room1 = " + Room.Id.ToString () + ") OR (Room2 = " + Room.Id.ToString () + "))) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
					CnnSS.Close ();
					}
				Room.Name = Conversions.ToString (NxDb.DS.Tables ["tblRooms"].Rows [rm] [1]);
				FileSystem.PrintLine (1, "<h4 style='color:red'>", Room.Name, "</h4>");
				Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
				string strTadakhol = "";
				bool TadakholExists = false;
                strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
				strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th><th>استاد</th></tr>";
				try
					{
					for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
						{
						for (int intDay = 0; intDay <= 5; intDay++)
							{
							for (int intThisRoom = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisRoom <= loopTo1; intThisRoom++)
								{
								if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [16], Room.Id, false))))
									{
									TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
									if (TermProg.TimeFlag [intDay, intTime] > 1)
										{
										strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [29]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [7]), "</td></tr>"), Constants.vbCrLf));
										TadakholExists = true;
										}
									}
								if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Conversion.Val (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [24]) == Room.Id)))
									{
									TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
									if (TermProg.TimeFlag [intDay, intTime] > 1)
										{
										strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [29]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [7]), "</td></tr>"), Constants.vbCrLf));
										TadakholExists = true;
										}
									}
								}
							}
						}
					}
				catch (Exception ex)
					{
					}
                strTadakhol += "</table>";
                strTadakhol += "</div>";
                strTadakhol += "</center>";
				if ((Report.Settings & 0x2) == 0x0)
					goto lblx;
				if ((Report.Settings & 0x200) == 0x200) // flag 512: show suggestions
					{
					if (TadakholExists == true)
						{
						FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
						FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
						FileSystem.PrintLine (1, strTadakhol);
						FileSystem.PrintLine (1, "<br>");
						}
					}
				//Main Table (Style A / B)
				FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه کلاس/آز</p>");
                FileSystem.PrintLine (1, "<center>");
                FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
                FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse; Text-Align:Center'>");
				if ((Report.Settings & 0x4) == 0x4) //Days of Week in ROWS (for Dr. RoshanZamir)
					{
					FileSystem.PrintLine (1, "<tr><th>روز</th><th>8:30</th><th>9:30</th><th>10:30</th><th>11:30</th><th>13:30</th><th>14:30</th><th>15:30</th><th>16:30</th></tr>");
					for (int intday = 0; intday <= 5; intday++)
						{
						FileSystem.PrintLine (1, "<tr><td>", TermProg.Day [intday], "</td>");                                 // Day of Week
						for (int intTime = 0; intTime <= 7; intTime++)
							{
							FileSystem.PrintLine (1, "<td>");
							for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo2; i++)
								{
								if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [16], Room.Id, false))))
									{
									if ((Report.Settings & 0x8) == 0x8)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");                                                 // 7 :Staff
									if ((Report.Settings & 0x10) == 0x10)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");            // 2 :CourseNumber
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");                                                // 29 :Entry
									if ((Report.Settings & 0x20) == 0x20)
										FileSystem.PrintLine (1, " گروه ", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "<br>");  // 5 :Group
									if ((Report.Settings & 0x40) == 0x40)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "<br>");           // 27:Exam
									}
								if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [24], Room.Id, false))))
									{
									if ((Report.Settings & 0x8) == 0x8)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");                                                 // 7 :Staff
									if ((Report.Settings & 0x10) == 0x10)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");            // 2 :CourseNumber
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");                                                // 29 :Entry
									if ((Report.Settings & 0x20) == 0x20)
										FileSystem.PrintLine (1, " گروه ", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "<br>");  // 5 :Group
									if ((Report.Settings & 0x40) == 0x40)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "<br>");           // 27:Exam
									}
								}
							FileSystem.PrintLine (1, "</td>");
							}
						FileSystem.PrintLine (1, "</tr>");
						}
					FileSystem.PrintLine (1, "</table><br>");
                    FileSystem.PrintLine (1, "</div>");
                    FileSystem.PrintLine (1, "</center>");
                    }
                else //Days of Week in COLS (for Mrs. Valipour)
					{
					FileSystem.PrintLine (1, "<tr><th>شماره</th><th>گ</th><th>نام درس</th><th>واحد</th><th>نام مدرس</th><th>کارشناس</th>");
					FileSystem.PrintLine (1, "<th>ش</th><th>ي</th><th>د</th><th>س</th><th>چ</th><th>پ</th>");
					FileSystem.PrintLine (1, "<th>امتحان</th><th>کلاس1</th><th>کلاس2</th><th>ظرفيت</th><th>يادداشت</th><th>ورودي</th></tr>");
					for (int i = 0, loopTo3 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo3; i++)
						{
						FileSystem.PrintLine (1, "<tr>");
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   // 2 :CourseNumber
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   // 5 :Group
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   // 3 :CourseName
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   // 4 :Unit
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   // 7 :Staff
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9], "</td>");   // 9 :Tech
						for (int intday = 0; intday <= 5; intday++)
							{
							string x = "";
							for (int intTime = 0; intTime <= 7; intTime++)
								{
								if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
									{
									x = x + TermProg.Time [intTime] + "<br>"; // Time
									}
								}
							FileSystem.PrintLine (1, "<td>", x, "</td>"); // Time
							}
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "</td>"); // 25:Exam
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "</td>"); // 17:Class1
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "</td>"); // 25:Class2
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [26], "</td>"); // 26:Capacity
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>"); // 28:Notes
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "</td>"); // 29:Ent
						FileSystem.PrintLine (1, "</tr>");
						}
					FileSystem.PrintLine (1, "</table><br>");
					FileSystem.PrintLine (1, "</div>");
					FileSystem.PrintLine (1, "</center>");
					}
			lblx:
				;

				if ((Report.Settings & 0x100) == 0x100)
					{
					// table: free times
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
					DrawFreeTimeTable ();
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
					}
				}
			//footer
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			NxDb.LOG ("rprt.class.prgs");
			Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_class_All.html");
			ComboBox1_SelectedIndexChanged (sender, e); //This is important to reset List of Entries back to original (for intUser, rather than intDept which is modified in frmReportSettings) 
			}
		private void Menu_ReportStaffPrograms_Click (object sender, EventArgs e)
			{
			//Report STAFFs
			//get departmentId and termId (to send them to frmReportsettings)
			if (ComboBox1.SelectedIndex != -1)
				{
				Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
				}
			else
				{
				Department.Id = 0L;
				}
			if (ListBox2.SelectedIndex != -1)
				{
				Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
				}
			else
				{
				Term.Id = 0L;
				}
			//get report settings
			My.MyProject.Forms.frmReportSettings.ShowDialog ();
			if (Nxt.Retval1 == 0)
				return;
			// intDept is set by frmReportSettings // or be as intUser ?
			if (Department.Id == 0L)
				{
				My.MyProject.Forms.ChooseDept.ShowDialog ();
				if (Department.Id == 0L)
					{
					return;
					}
				}
			//read staff tbl
			NxDb.DS.Tables ["tblStaff"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" + Department.Id.ToString () + " ORDER BY StaffName", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblStaff");
				CnnSS.Close ();
				}
			FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_staff_All.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir= \"rtl\">");
			if ((Report.Settings & 0x80) == 0x80)
				{
				FileSystem.PrintLine (1, "<head>");
				FileSystem.PrintLine (1, "<title>برنامه استاد</title>");
				FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
				FileSystem.PrintLine (1, "</head>");
				}
			else
				{
				FileSystem.PrintLine (1, "<head>");
				FileSystem.PrintLine (1, "<title>برنامه استاد</title>");
				FileSystem.PrintLine (1, Report.StyleSinBg); // strReportsStyle is defined in Module1
				FileSystem.PrintLine (1, "</head>");
				}
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
			FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><p style='color:blue;text-align: center'>" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "</p><hr>");
			for (int stf = 0, loopTo = NxDb.DS.Tables ["tblStaff"].Rows.Count - 1; stf <= loopTo; stf++)
				{
				Staff.Id = Conversions.ToLong (NxDb.DS.Tables ["tblStaff"].Rows [stf] [0]);
				NxDb.DS.Tables ["tblAllProgs"].Clear ();
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
					CnnSS.Close ();
					}
				Staff.Name = Conversions.ToString (NxDb.DS.Tables ["tblStaff"].Rows [stf] [1]);
				FileSystem.PrintLine (1, "<h4 style='color:red'>", Staff.Name, "</h4>");
				Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
				string strTadakhol = "";
				bool TadakholExists = false;
                strTadakhol += "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>";
				strTadakhol += "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th></tr>";
				for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
					{
					for (int intDay = 0; intDay <= 5; intDay++) // each day
						{
						for (int intThisStaff = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo1; intThisStaff++)
							{
							if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
								{
								TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
								if (TermProg.TimeFlag [intDay, intTime] > 1)
									{
									strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [29]), "</td></tr>"), Constants.vbCrLf));
									TadakholExists = true;
									}
								}
							if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
								{
								TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
								if (TermProg.TimeFlag [intDay, intTime] > 1)
									{
									strTadakhol = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (strTadakhol + "<tr><td>" + TermProg.Day [intDay] + "</td><td>" + TermProg.Time [intTime] + "</td><td>", NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [3]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [5]), "</td><td>"), NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [29]), "</td></tr>"), Constants.vbCrLf));
									TadakholExists = true;
									}
								}
							}
						}
					}
                strTadakhol += "</table>";
                strTadakhol += "</div>";
                strTadakhol += "</center>";
				if ((Report.Settings & 0x2) == 0x0)
					goto lblx;
				if ((Report.Settings & 0x200) == 0x200) // flag 512: show suggestions
					{
					if (TadakholExists == true)
						{
						FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
						FileSystem.PrintLine (1, "براي رفع تداخل، زمان بندي دروس زير را تغيير دهيد", "<br></p>");
						FileSystem.PrintLine (1, strTadakhol);
						FileSystem.PrintLine (1, "<br>");
						}
					}
				//Main Table (Style A / B)
				FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه استاد</p>");
                FileSystem.PrintLine (1, "<center>");
                FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
                FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse; Text-Align:Center'>");
				if ((Report.Settings & 0x4) == 0x4) //Days of Week in ROWS (for Dr. RoshanZamir)
					{
					FileSystem.PrintLine (1, "<tr><th>روز</th><th>8:30</th><th>9:30</th><th>10:30</th><th>11:30</th><th>13:30</th><th>14:30</th><th>15:30</th><th>16:30</th></tr>");
					for (int intday = 0; intday <= 5; intday++)
						{
						FileSystem.PrintLine (1, "<tr><td>", TermProg.Day [intday], "</td>");                                 // Day of Week
						for (int intTime = 0; intTime <= 7; intTime++)
							{
							FileSystem.PrintLine (1, "<td>");
							for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo2; i++)
								{
								if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
									{
									if ((Report.Settings & 0x8) == 0x8)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
									if ((Report.Settings & 0x10) == 0x10)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");            // 2 :CourseNumber
									if ((Report.Settings & 0x20) == 0x20)
										FileSystem.PrintLine (1, " گروه ", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "<br>");  // 5 :Group
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");                                                    // 29 :Entry
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "<br>");                                                    // 17 :Class1
									if ((Report.Settings & 0x40) == 0x40)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "<br>");           // 27:Exam
									}
								if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
									{
									if ((Report.Settings & 0x8) == 0x8)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
									if ((Report.Settings & 0x10) == 0x10)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");            // 2 :CourseNumber
									if ((Report.Settings & 0x20) == 0x20)
										FileSystem.PrintLine (1, " گروه ", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "<br>");  // 5 :Group
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");                                                    // 29 :Entry
									FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "<br>");                                                    // 25 :Class2
									if ((Report.Settings & 0x40) == 0x40)
										FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "<br>");           // 27:Exam
									}
								}
							FileSystem.PrintLine (1, "</td>");
							}
						FileSystem.PrintLine (1, "</tr>");
						}
					FileSystem.PrintLine (1, "</table><br>");
                    FileSystem.PrintLine (1, "</div>");
                    FileSystem.PrintLine (1, "</center>");
                    }
                else //Days of Week in COLS (for Mrs. Valipour)
					{
					FileSystem.PrintLine (1, "<tr><th>شماره</th><th>گ</th><th>نام درس</th><th>واحد</th><th>نام مدرس</th><th>کارشناس</th>");
					FileSystem.PrintLine (1, "<th>ش</th><th>ي</th><th>د</th><th>س</th><th>چ</th><th>پ</th>");
					FileSystem.PrintLine (1, "<th>امتحان</th><th>کلاس1</th><th>کلاس2</th><th>ظرفيت</th><th>يادداشت</th><th>ورودي</th></tr>");
					for (int i = 0, loopTo3 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo3; i++)
						{
						FileSystem.PrintLine (1, "<tr>");
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "</td>");   // 2 :CourseNumber
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5], "</td>");   // 5 :Group
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "</td>");   // 3 :CourseName
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4], "</td>");   // 4 :Unit
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "</td>");   // 7 :Staff
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9], "</td>");   // 9 :Tech
						for (int intday = 0; intday <= 5; intday++)
							{
							string x = "";
							for (int intTime = 0; intTime <= 7; intTime++)
								{
								if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
									{
									x = x + TermProg.Time [intTime] + "<br>"; // Time
									}
								}
							FileSystem.PrintLine (1, "<td>", x, "</td>"); // Time
							}
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27], "</td>"); // 27:Exam
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17], "</td>"); // 17:Class1
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25], "</td>"); // 25:Class2
						FileSystem.PrintLine (1, "<td style= 'Text-Align:Center'>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [26], "</td>"); // 26:Capacity
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [28], "</td>"); // 28:Notes
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "</td>"); // 29:Ent
						FileSystem.PrintLine (1, "</tr>");
						}
					FileSystem.PrintLine (1, "</table><br>");
					FileSystem.PrintLine (1, "</div>");
					FileSystem.PrintLine (1, "</center>");
					}
			lblx:
				;
				if ((Report.Settings & 0x100) == 0x100)
					{
					// table: free times
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>");
					DrawFreeTimeTable ();
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p>");
					}
				if ((Report.Settings & 0x2) == 0x0)
					goto lblx2;
				// table: Exams dates for Staff
				if ((Report.Settings & 0x400) == 0x400)
					{
					NxDb.DS.Tables ["tblTermExams"].Clear ();
					using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
						{
						CnnSS.Open ();
						NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY ExamDate", CnnSS);
						NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
						CnnSS.Close ();
						}
					FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه امتحانات</p>");
                    FileSystem.PrintLine (1, "<center>");
                    FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
                    FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
					FileSystem.PrintLine (1, "<tr><th>تاريخ</th>");
					FileSystem.PrintLine (1, "<th>درس</th>");
					FileSystem.PrintLine (1, "<th>ورودي</th></tr>");
					for (int i = 0, loopTo4 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo4; i++)
						{
						FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [1], "</td>");  // 1 :Exam
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [2], "</td>");      // 2 :Course
						FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [7], "</td></tr>"); // 7 :Entry string
						}
					FileSystem.PrintLine (1, "</table><br>");
                    FileSystem.PrintLine (1, "</div>");
                    FileSystem.PrintLine (1, "</center>");
					}
			lblx2:
				;
				}
			//footer
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body></html>");
			FileSystem.FileClose (1);
			NxDb.LOG ("rprt.staff.prgs");
			Interaction.Shell ("explorer.exe " + System.Windows.Forms.Application.StartupPath + "Nexterm_staff_All.html");
			//reset back the list of Entries to original (for intUser, rather than intDept which is modified in frmReportSettings) 
			ComboBox1_SelectedIndexChanged (sender, e);
			}
		private void Menu_ReportStaffPrograms_Word_Click (object sender, EventArgs e)
			{
			//Report STAFFs
			//get departmentId and termId (to send them to frmReportsettings)
			int currentRow = 0;
            if (ComboBox1.SelectedIndex != -1)
				{
				Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
				}
			else
				{
				Department.Id = 0L;
				}
			if (ListBox2.SelectedIndex != -1)
				{
				Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
				}
			else
				{
				Term.Id = 0L;
				}
			//get report settings
			My.MyProject.Forms.frmReportSettings.ShowDialog ();
			if (Nxt.Retval1 == 0)
				return;
			// intDept is set by frmReportSettings // or be as intUser ?
			if (Department.Id == 0L)
				{
				My.MyProject.Forms.ChooseDept.ShowDialog ();
				if (Department.Id == 0L)
					{
					return;
					}
				}
            //progressBar1
            progressBar1.Visible = true;
            progressBar1.Minimum=0;
            //read staff tbl
            NxDb.DS.Tables ["tblStaff"].Clear ();
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" + Department.Id.ToString () + " ORDER BY StaffName", CnnSS);
				NxDb.DASS.Fill (NxDb.DS, "tblStaff");
				CnnSS.Close ();
				}
			progressBar1.Maximum = NxDb.DS.Tables ["tblStaff"].Rows.Count;
            //
            object missing = System.Reflection.Missing.Value;
			NxDb.Filename = Application.StartupPath + @"Nexterm_staff_All.docx";
			Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application ();
			Microsoft.Office.Interop.Word.Document WordDoc = null;
			WordApp.Visible = false;
			WordApp.ShowAnimation = false;
			WordDoc = WordApp.Documents.Add ();
			WordDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
			WordDoc.PageSetup.LeftMargin = WordApp.InchesToPoints (0.5f);
			WordDoc.PageSetup.RightMargin = WordApp.InchesToPoints (0.5f);
			//paragraph-1
			WordDoc.Paragraphs [1].Range.Font.Name = "Calibri";
			WordDoc.Paragraphs [1].Range.Font.Size = 10;
			WordDoc.Paragraphs [1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
			string strParagraphText = "برنامه اساتيد" + Environment.NewLine;
			strParagraphText = strParagraphText + Report.AppOwner + Environment.NewLine;
			strParagraphText = strParagraphText + Term.Name + "  " + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + Environment.NewLine;
			WordDoc.Paragraphs [1].Range.InsertAfter (strParagraphText);
			WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
			//
			for (int stf = 0, loopTo = NxDb.DS.Tables ["tblStaff"].Rows.Count - 1; stf <= loopTo; stf++)
				{
                Staff.Id = Conversions.ToLong (NxDb.DS.Tables ["tblStaff"].Rows [stf] [0]);
				progressBar1.Value = stf + 1;
				NxDb.DS.Tables ["tblAllProgs"].Clear ();
				using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
					{
					CnnSS.Open ();
					NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
					NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
					CnnSS.Close ();
					}
				if (NxDb.DS.Tables ["tblAllProgs"].Rows.Count > 0)
					{
					WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range.InsertBreak (WdBreakType.wdSectionBreakNextPage);
					//print Staff.Name
					Staff.Name = Conversions.ToString (NxDb.DS.Tables ["tblStaff"].Rows [stf] [1]);
					WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range.Text = Staff.Name;
					Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); //clear data in intTimeFlag (r:6days, c:8times //begins from 0)
					//mainTable (style A/B)
					WordDoc.Paragraphs.Add ();
					if ((Report.Settings & 0x4) == 0x4) //Days of Week in ROWS (for Dr. RoshanZamir)
						{
						WordDoc.Tables.Add (WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range, 1, 9, WdAutoFitBehavior.wdAutoFitWindow);
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 1).Range.Text = "روز";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 2).Range.Text = "8:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 3).Range.Text = "9:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 4).Range.Text = "10:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 5).Range.Text = "11:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 6).Range.Text = "13:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 7).Range.Text = "14:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 8).Range.Text = "15:30";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 9).Range.Text = "16:30";
						string cellString = "";
						for (int intday = 0; intday <= 5; intday++)
							{
							WordDoc.Tables [WordDoc.Tables.Count].Rows.Add ();
							currentRow = WordDoc.Tables [WordDoc.Tables.Count].Rows.Count;
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 1).Range.Text = TermProg.Day [intday]; // Day of Week
							for (int intTime = 0; intTime <= 7; intTime++)
								{
								for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo2; i++)
									{
									cellString = "";
									if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
										{
										if ((Report.Settings & 0x8) == 0x8)
											cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3].ToString() + "\n");              // 3 :CourseName
										if ((Report.Settings & 0x10) == 0x10)
											cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2].ToString() + "\n");              // 2 :CourseNumber
										if ((Report.Settings & 0x20) == 0x20)
											cellString += (" گروه " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5].ToString() + "\n");   // 5 :Group
										cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29].ToString() + "\n");                 // 29 :Entry
										cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17].ToString() + "\n");                 // 17 :Class1
										if ((Report.Settings & 0x40) == 0x40)
											cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27].ToString() + "\n");             // 27:Exam
										WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, intTime +2 ).Range.Text = cellString;
										}
									cellString = "";
									if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
										{
										if ((Report.Settings & 0x8) == 0x8)
											cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3].ToString() + "\n");              // 3 :CourseName
										if ((Report.Settings & 0x10) == 0x10)
											cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2].ToString() + "\n");              // 2 :CourseNumber
										if ((Report.Settings & 0x20) == 0x20)
											cellString += (" گروه " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5].ToString() + "\n");   // 5 :Group
										cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29].ToString() + "\n");                 // 29 :Entry
										cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25].ToString() + "\n");                 // 25 :Class2
										if ((Report.Settings & 0x40) == 0x40)
											cellString += (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [27].ToString() + "\n");             // 27:Exam
										WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, intTime + 2).Range.Text = cellString;
										}
									}
								}
							}
						}
					else //Days of Week in COLS (for Mrs. Valipour)
						{
						WordDoc.Tables.Add (WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range, 1, 15, WdAutoFitBehavior.wdAutoFitWindow);
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 1).Range.Text = "شماره";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 2).Range.Text = "گروه";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 3).Range.Text = "نام درس";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 4).Range.Text = "واحد";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 5).Range.Text = "نام مدرس";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 6).Range.Text = "کارشناس";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 7).Range.Text = "ش";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 8).Range.Text = "ي";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 9).Range.Text = "د";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 10).Range.Text = "س";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 11).Range.Text = "چ";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 12).Range.Text = "پ";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 13).Range.Text = "کلاس1";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 14).Range.Text = "کلاس2";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 15).Range.Text = "ورودي";
						string cellString = "";
						for (int i = 0, loopTo3 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo3; i++)
							{
							WordDoc.Tables [WordDoc.Tables.Count].Rows.Add ();
							currentRow = WordDoc.Tables [WordDoc.Tables.Count].Rows.Count;
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 1).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2].ToString();   // 2 :CourseNumber
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 2).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [5].ToString();   // 5 :Group
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 3).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3].ToString();   // 3 :CourseName
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 4).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [4].ToString();   // 4 :Unit
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 5).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7].ToString();   // 7 :Staff
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 6).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [9].ToString ();   // 9 :Tech
							for (int intday = 0; intday <= 5; intday++)
								{
								string x = "";
								for (int intTime = 0; intTime <= 7; intTime++)
									{
									if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))))
										{
										x = x + TermProg.Time [intTime] + "\n"; // Time
										}
									}
								WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, intday + 7).Range.Text = x; // Time
								}
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 13).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17].ToString(); // 17:Class1
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 14).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25].ToString(); // 25:Class2
							WordDoc.Tables [WordDoc.Tables.Count].Cell (currentRow, 15).Range.Text = NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29].ToString(); // 29:Ent
							}
						}
				lblx:
					;
					if ((Report.Settings & 0x2) == 0x0)
						goto lblx2;
					// table: Exams dates for Staff
					if ((Report.Settings & 0x400) == 0x400)
						{
						NxDb.DS.Tables ["tblTermExams"].Clear ();
						using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
							{
							CnnSS.Open ();
							NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY ExamDate", CnnSS);
							NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
							CnnSS.Close ();
							}
						WordDoc.Paragraphs.Add ();
						WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range.Text = "برنامه امتحانات";
						WordDoc.Paragraphs.Add ();
						WordDoc.Tables.Add (WordDoc.Paragraphs [WordDoc.Paragraphs.Count].Range, 1, 3, WdAutoFitBehavior.wdAutoFitWindow);
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 1).Range.Text = "تاريخ";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 2).Range.Text = "درس";
						WordDoc.Tables [WordDoc.Tables.Count].Cell (1, 3).Range.Text = "ورودي";
						for (int i = 0, loopTo4 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo4; i++)
							{
							WordDoc.Tables [WordDoc.Tables.Count].Rows.Add ();
							WordDoc.Tables [WordDoc.Tables.Count].Cell (i + 2, 1).Range.Text = NxDb.DS.Tables ["tblTermExams"].Rows [i] [1].ToString ();   // 1 :Exam
							WordDoc.Tables [WordDoc.Tables.Count].Cell (i + 2, 2).Range.Text = NxDb.DS.Tables ["tblTermExams"].Rows [i] [2].ToString();    // 2 :Course
							WordDoc.Tables [WordDoc.Tables.Count].Cell (i + 2, 3).Range.Text = NxDb.DS.Tables ["tblTermExams"].Rows [i] [7].ToString();    // 7 :Entry string
							}
						}
                lblx2:
                    ;
					}
				}
            //save-doc
            WordApp.Visible = true;
            WordDoc.SaveAs2 (NxDb.Filename);
            //WordDoc.Close ();
            //WordDoc = null;
            //WordApp.Quit ();
            //WordApp = null;
            MessageBox.Show ("فايل ورد گزارش در آدرس زير ذخيره شد\n\n" + NxDb.Filename);
            progressBar1.Visible = false;
            //Log
            NxDb.LOG ("rprt.staff.prgs");
			//reset back the list of Entries to original (for intUser, rather than intDept which is modified in frmReportSettings) 
			ComboBox1_SelectedIndexChanged (sender, e);
			}
		private void Menu_UserActivityLogs_Click (object sender, EventArgs e)
			{
			Department.Id = Conversions.ToLong (ComboBox1.SelectedValue);
			Term.Id = Conversions.ToLong (ListBox2.SelectedValue);
			My.MyProject.Forms.UserActivityLog.ShowDialog ();
			ListBox1_Click (sender, e);
			}
		//CMD (in main menu)
		private void frmTermProgs_KeyDown (object sender, KeyEventArgs e)
			{
			if (e.KeyCode.ToString () == "F2")
				{
				if (Menu_CMD.Visible == true)
					{
					cmdLineStatus0 = 0;
					Menu_CMD.Text = ">hide";
					}
				else
					{
					Menu_CMD.Visible = true;
					Menu_CMD.Focus ();
					Menu_CMD.Text = "> cmd";
					Menu_CMD.SelectionStart = 1;
					Menu_CMD.SelectionLength = 4;
					}
				}
			}
		private void Menu_CMD_TextChanged (object sender, EventArgs e)
			{
			if (string.IsNullOrEmpty (Menu_CMD.Text))
				{
				Menu_CMD.Text = ">command";
				Menu_CMD.SelectionStart = 1;
				Menu_CMD.SelectionLength = 7;
				return;
				}
			try
				{
				switch (cmdLineStatus0)
					{
					case 0: //ready for commands
							{
							switch (Strings.Trim (Menu_CMD.Text.ToLower ()))
								{
								case "word":
									Nxt.CreateDocument ();
									break;
								case "hide":
								case ">hide":
									ComboBox1.Focus ();
									Menu_CMD.Visible = false;
									break;
								case "keyless":
								case ">keyless":
									Menu_CMD.Text = ">keyless  on / off ";
									Menu_CMD.SelectionStart = 9;
									Menu_CMD.SelectionLength = 10;
									break;
								case ">keyless on":
									if (NxDb.AddKeyless () == true)
										{
										Menu_CMD.Text = " keyless is Enabled! ";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = Menu_CMD.TextLength;
										}
									else
										{
										Menu_CMD.Text = "keyless not changed!";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = Menu_CMD.TextLength;
										}
									break;
								case ">keyless off":
									NxDb.RemoveKeyless ();
									Menu_CMD.Text = " keyless is Disabled! ";
									Menu_CMD.SelectionStart = 0;
									Menu_CMD.SelectionLength = Menu_CMD.TextLength;
									break;
								case ">help":
								case "help":
								case ">cmd":
								case "cmd":
								case ">guide":
								case "guide":
										{
										cmdHelp ();
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">user":
								case "user":
										{
										Menu_Userx_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">pass":
								case "pass":
										{
										Menu_ChangePass_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">sett":
								case "sett":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										if (User.Type == "UserDeputy" | User.Id == 0)
											Menu_Settings_Click (sender, e);
										break;
										}
								case ">info":
								case "info":
										{
										Menu_About_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">note":
								case "note":
										{
										Menu_Messenger_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">end":
								case "end":
								case ">quit":
								case "quit":
								case ">exit":
								case "exit":
									Menu_CMD.Text = ">Exit yes / no";
									Menu_CMD.SelectionStart = 6;
									Menu_CMD.SelectionLength = 8;
									break;
								case ">exit y":
										{
										DoExitNexTerm ();
										break;
										}
								case ">exit n":
									Menu_CMD.Text = "";
									break;
								case ">res":
								case "res":
								case ">org":
								case "org":
										{
										Menu_Departments_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">cour":
								case "cour":
										{
										Menu_Courses_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">room":
								case "room":
								case ">lab":
								case "lab":
										{
										Menu_Classes_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">term":
								case "term":
										{
										Menu_Terms_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">staff":
								case "staff":
										{
										Menu_Staff_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">tech":
								case "tech":
										{
										Menu_Tech_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">templ":
								case "templ":
										{
										Menu_Templates (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">rev":
								case "rev":
										{
										Menu_ReviewPrograms_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">rep":
								case "rep":
									Menu_CMD.Text = ">Report Entry / Class / Staff / Activity";
									Menu_CMD.SelectionStart = 8;
									Menu_CMD.SelectionLength = 32;
									break;
								case ">report e":
										{
										Menu_ReportEntriesPrograms_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">report c":
										{
										Menu_ReportClassPrograms_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">report s":
										{
										Menu_ReportStaffPrograms_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">report a":
										{
										Menu_UserActivityLogs_Click (sender, e);
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										break;
										}
								case ">def":
								case "def":
										{
										Menu_TermsDefault_Set_Click (sender, e);
										if (TermProg.DefaultTermId > 0)
											{
											Menu_CMD.Text = "[Def.Term.ID: " + TermProg.DefaultTermId.ToString () + "]";
											Menu_CMD.SelectionStart = 0;
											Menu_CMD.SelectionLength = Strings.Len (Menu_CMD.Text);
											}
										else
											{
											Menu_CMD.Text = "";
											}
										cmdLineStatus0 = 0;
										break;
										}
								//new cases from frmSettings
								case ">class":
								case "class":
									Menu_CMD.Text = ">Class on / off";
									Menu_CMD.SelectionStart = 7;
									Menu_CMD.SelectionLength = 8;
									break;
								case ">class on":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										User.ACCs = User.ACCs | 0x4; // 0x04=4=0000'0100
										DirectSave2Settings (1);
										EnableMenu ();
										NxDb.LOG ("sttng:class.on");
										Menu_CMD.Text = "[Class : On]";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = 12;
										break;
										}
								case ">class off":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										User.ACCs = User.ACCs & 0xFB; // 0xfb=251=1111'1011
										DirectSave2Settings (2);
										EnableMenu ();
										NxDb.LOG ("sttng:class.off");
										Menu_CMD.Text = "[Class : Off]";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = 13;
										break;
										}
								case ">prog":
								case "prog":
									Menu_CMD.Text = ">Prog on / off";
									Menu_CMD.SelectionStart = 6;
									Menu_CMD.SelectionLength = 8;
									break;
								case ">prog on":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										User.ACCs = User.ACCs | 0x10; // 0x10=16=0001'0000
										DirectSave2Settings (3);
										EnableMenu ();
										NxDb.LOG ("sttng:prog.on");
										Menu_CMD.Text = "[Prog : On]";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = 11;
										break;
										}
								case ">prog off":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										User.ACCs = User.ACCs & 0xEF; // 0xef=239=1110'1111
										DirectSave2Settings (4);
										EnableMenu ();
										NxDb.LOG ("sttng:prog.off");
										Menu_CMD.Text = "[Prog : Off]";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = 12;
										break;
										}
								case ">log":
								case "log":
									Menu_CMD.Text = ">Log on / off";
									Menu_CMD.SelectionStart = 5;
									Menu_CMD.SelectionLength = 8;
									break;
								case ">log on":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										Setting.WriteLogs = true;
										DirectSave2Settings (5);
										NxDb.LOG ("sttng:usr.log on");
										Menu_CMD.Text = "[Log : On]";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = 10;
										break;
										}
								case ">log off":
										{
										Menu_CMD.Text = "";
										cmdLineStatus0 = 0;
										Setting.WriteLogs = false;
										DirectSave2Settings (6);
										NxDb.LOG ("sttng:usr.log off");
										Menu_CMD.Text = "[Log : Off]";
										Menu_CMD.SelectionStart = 0;
										Menu_CMD.SelectionLength = 11;
										break;
										}
								/////////Parametric cases
								case "wipeout": //cmd1 with parameter
										{
										cmdLineStatus0 = 1; //be ready for input parameters
										Menu_CMD.Text = "Messages | ProgData | Entries | ClearAllData";
										Menu_CMD.SelectionStart = Strings.Len (Menu_CMD.Text);
										break;
										}
								case ">exam":
								case "exam":
									Menu_CMD.Text = ">ExamDates start / end";
									Menu_CMD.SelectionStart = 11;
									Menu_CMD.SelectionLength = 11;
									break;
								case ">examdates start":
								case "examdates start":
										{
										cmdLineStatus0 = 2; //be ready for input parameters
										if (string.IsNullOrEmpty (Term.ExamDateStart))
											Menu_CMD.Text = "1402.03.01";
										else
											Menu_CMD.Text = Term.ExamDateStart;
										Menu_CMD.SelectionStart = Menu_CMD.TextLength - 2;
										Menu_CMD.SelectionLength = 2;
										break;
										}
								case ">examdates end":
								case "examdates end":
										{
										cmdLineStatus0 = 3; //be ready for input parameters
										if (string.IsNullOrEmpty (Term.ExamDateEnd))
											{
											Menu_CMD.Text = "1402.04.15";
											Menu_CMD.SelectionStart = Menu_CMD.TextLength - 2;
											Menu_CMD.SelectionLength = 2;
											}
										else
											{
											Menu_CMD.Text = Term.ExamDateEnd;
											Menu_CMD.SelectionStart = Menu_CMD.TextLength - 2;
											Menu_CMD.SelectionLength = 2;
											}
										break;
										}
								}
							break;
							}
					case 1: //input parameter for cmd1 (WipeOut)
							{
							if (Strings.Mid (Menu_CMD.Text, Strings.Len (Menu_CMD.Text), 1) == "#")
								{
								string sttng = Strings.Mid (Menu_CMD.Text, 1, Strings.Len (Menu_CMD.Text) - 1);
								NxDb.WipeOut_NxInfo (sttng);
								if (Nxt.Retval1 == 1)
									{
									NxDb.LOG ("nexterm wipeout--! done");
									Menu_CMD.Text = "Data Cleared";
									Menu_CMD.SelectionStart = 0;
									Menu_CMD.SelectionLength = Menu_CMD.TextLength;
									}
								else
									{
									NxDb.LOG ("nxterm wipeout--! cancelled"); //37:Done, 38:Cancelled
									Menu_CMD.Text = "Operation Cancelled By User";
									Menu_CMD.SelectionStart = 0;
									Menu_CMD.SelectionLength = Menu_CMD.TextLength;
									}
								cmdLineStatus0 = 0; // reset, ready for commands
								}
							break;
							}
					case 2: //strExamDateStart
							{
							if (Strings.Mid (Menu_CMD.Text, Strings.Len (Menu_CMD.Text), 1) == "#")
								{
								string sttng = Strings.Mid (Menu_CMD.Text, 1, Strings.Len (Menu_CMD.Text) - 1);
								//write to sttng table
								Term.ExamDateStart = Strings.Mid (Menu_CMD.Text, 1, Strings.Len (Menu_CMD.Text) - 1);
								cmdLineStatus0 = 0; // reset, ready for commands
								Menu_CMD.Text = "ExamDate Start Changed";
								Menu_CMD.SelectionStart = 0;
								Menu_CMD.SelectionLength = Menu_CMD.TextLength;
								NxDb.LOG ("exams start date" + Term.ExamDateStart);
								}
							break;
							}
					case 3: //strExamDateEnd
							{
							if (Strings.Mid (Menu_CMD.Text, Strings.Len (Menu_CMD.Text), 1) == "#")
								{
								string sttng = Strings.Mid (Menu_CMD.Text, 1, Strings.Len (Menu_CMD.Text) - 1);
								//write to sttng table
								Term.ExamDateEnd = Strings.Mid (1.ToString (), Conversions.ToInteger (Menu_CMD.Text), Strings.Len (Menu_CMD.Text) - 1);
								cmdLineStatus0 = 0; // reset, ready for commands
								Menu_CMD.Text = "ExamDate End Changed";
								Menu_CMD.SelectionStart = 0;
								Menu_CMD.SelectionLength = Menu_CMD.TextLength;
								NxDb.LOG ("exams end date" + Term.ExamDateEnd);
								}
							break;
							}
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show (ex.ToString ());
				}
			}
		private void DirectSave2Settings (int commandID)
			{
			switch (commandID)
				{
				case 1:
						{
						NxDb.strSQL = "UPDATE Settings SET SettingsValue = 'YES' WHERE SettingsKey = 'Officer can Class'";
						break;
						}
				case 2:
						{
						NxDb.strSQL = "UPDATE Settings SET SettingsValue = 'NO'  WHERE SettingsKey = 'Officer can Class'";
						break;
						}
				case 3:
						{
						NxDb.strSQL = "UPDATE Settings SET SettingsValue = 'YES' WHERE SettingsKey = 'Officer can Prog'";
						break;
						}
				case 4:
						{
						NxDb.strSQL = "UPDATE Settings SET SettingsValue = 'NO'  WHERE SettingsKey = 'Officer can Prog'";
						break;
						}
				case 5:
						{
						NxDb.strSQL = "UPDATE Settings SET SettingsValue = 'YES' WHERE SettingsKey = 'Log'";
						break;
						}
				case 6:
						{
						NxDb.strSQL = "UPDATE Settings SET SettingsValue = 'NO'  WHERE SettingsKey = 'Log'";
						break;
						}
				}
			using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
				{
				CnnSS.Open ();
				var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
				cmd.CommandType = CommandType.Text;
				int i = cmd.ExecuteNonQuery ();
				CnnSS.Close ();
				}
			}
		private void cmdHelp ()
			{
			FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
			FileSystem.PrintLine (1, "<html dir=\"rtl\">");
			FileSystem.PrintLine (1, "<head>");
			FileSystem.PrintLine (1, "<title>راهنما</title>");
			FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
			FileSystem.PrintLine (1, "</head>");
			FileSystem.PrintLine (1, "<body>");
			FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>دانشکده علوم پايه، دانشگاه شهرکرد</p>");
			FileSystem.PrintLine (1, "<hr>");
			FileSystem.PrintLine (1, "<p style='color:blue;font-family:tahoma; font-size:14px'>راهنماي خط فرمان در پايين صفحه اصلي نکسترم<br></p>");
			FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><Quick list</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:14px; border-collapse:collapse'>");
			// Header
			FileSystem.PrintLine (1, "<tr><th></th><th>فرمان</th><th>عمل</th</tr>");
			// Rows
			FileSystem.PrintLine (1, "<tr><td>کارشناس آموزش</td>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> rep ent   </td> <td> گزارش برنامه ورودي ها                    </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> rep class </td> <td> گزارش برتامه کلاس ها                      </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> rep staff </td> <td> گزارش برنامه اساتيد                      </td></tr>");
			FileSystem.PrintLine (1, "<tr><td>معاون آموزشي</td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> note       </td> <td> يادداشت ها                                 </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> sett       </td> <td> تنظيمات                                    </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> res        </td> <td> منابع                                      </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> rev        </td> <td> مرور برنامه اساتيد                         </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> act        </td> <td> گزازش فعاليت کاربران                       </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> term       </td> <td> ويرايش ليست ترم ها - احتياط                </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> tech       </td> <td> ويرايش ليست کارشناسان                      </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> room       </td> <td> ويرايش ليست کلاس ها                         </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> user       </td> <td> تغيير کاربر                                </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> exam start </td> <td> تاريخ شروع امتحانات                        </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> exam end   </td> <td> تاريخ پايان امتحانات                       </td></tr>");

			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> prog on      </td> <td> کاربر دانشکده مي تواند مانند مدير گروه برنامه ريزي کند       </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> prog off     </td> <td> کاربر دانشکده نمي تواند برنامه ريزي کند - فقط گزارش گيري     </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> class on     </td> <td> کاربر دانشکده مي تواند کلاس بندي انجام دهد / مانند مدير گروه  </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> class off    </td> <td> تغيير کاربکاربر دانشکده نمي تواند کلاي بندي انجام دهد         </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> log on       </td> <td> ثبت فعاليت کاربران در سيستم: ورود و خروج و تغييرات مهم در برنامه ها ثبت مي شوند        </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> log off      </td> <td> فعاليت کاربران در ديتابيس ثبت نشود   </td></tr>");

			FileSystem.PrintLine (1, "<tr><td>مديران گروه ها</td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> pass    </td> <td> تغيير پسورد                                </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> temp    </td> <td> طراحي الگوي برنامه ريزي                    </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> cour    </td> <td> ويرايش درس ها                              </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> staff   </td> <td> ويرايش ليست اساتيد                         </td></tr>");
			FileSystem.PrintLine (1, "<tr><td>فرامين عمومي</td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> cmd     </td> <td> ليست دستورات                               </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> def     </td> <td> ترم پيش فرض شود                            </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> quit    </td> <td> خروج از نکسترم                             </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> exit    </td> <td> خروج از نکسترم                             </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> help    </td> <td> 'www.msht.ir'                              </td></tr>");
			FileSystem.PrintLine (1, "<tr><td></td> <td style= 'Text-Align:Center'> about   </td> <td> صفحه آبي معرفي نکسترم                      </td></tr>");
			FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
			FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
			FileSystem.PrintLine (1, "</body>");
			FileSystem.PrintLine (1, "</html>");
			FileSystem.FileClose (1);
			Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
			}
		//LOG
		private void frmTermProgs_FormClosing (object sender, FormClosingEventArgs e)
			{
			if (e.CloseReason == CloseReason.UserClosing)
				{
				e.Cancel = true;
				// MsgBox("براي خروج از برنامه از منو استفاده کنيد ", vbOKOnly, "نکسترم")
				}
			}
		//EXIT
		private void DoExitNexTerm ()
			{
			NxDb.LOG ("logout");
			try
				{
				My.MyProject.Forms.frmCNN.Dispose ();
				My.MyProject.Forms.ChooseStaff.Dispose ();
				My.MyProject.Forms.ChooseTech.Dispose ();
				Dispose ();
				Environment.Exit (0);
				Application.Exit ();
				Application.ExitThread ();
				}
			catch (Exception ex)
				{
				MessageBox.Show ("Error in Exit module ...." + Constants.vbCrLf + ex.ToString ());
				}
			}

		private void lblExit_Click (object sender, EventArgs e)
			{
			DoExitNexTerm ();
			}
		}
	}