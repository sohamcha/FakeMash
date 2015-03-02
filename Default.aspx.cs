using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    static Random rand;
    static int i = 0, j = 0,l = 1,flag = 1,s=33,count=1,win,lost;
    static float rating,expi,expj,newrating,oldrating,sum=0;
    static bool rndm = false,LOCK=false;
    //static float[] exp;
    //static float[] rating;
    //static int[] votes;
    static int[] visited;
    static SqlConnection cn;   
    static SqlCommand cmd;
    static SqlDataReader rd;


    protected void gettotalrating(int k)
    {
        cmd = new SqlCommand("SELECT SUM(RATING) FROM MAIN WHERE ID!=" + k, cn);
              rd = cmd.ExecuteReader();
              rd.Read();
              sum = (float)(rd.GetDouble(0));
        
              rd.Close();
    }
   
    protected int getwin(int k)
    {
        cmd = new SqlCommand("SELECT WIN FROM MAIN WHERE ID=" + k, cn);
        rd = cmd.ExecuteReader();
        rd.Read();
        k = rd.GetInt32(0);
        rd.Close();
        return k;
    }
   
    protected int getlost(int k)
    {
        cmd = new SqlCommand("SELECT LOST FROM MAIN WHERE ID=" + k, cn);
        rd = cmd.ExecuteReader();
        rd.Read();
        k = rd.GetInt32(0);
        rd.Close();
        return k;
    }

    protected float getrating(int k)
    {
        float p;
        cmd = new SqlCommand("SELECT RATING FROM MAIN WHERE ID=" + k, cn);
        rd = cmd.ExecuteReader();
        rd.Read();
        p = (float)(rd.GetDouble(0));
        rd.Close();
        return p;
    }

    protected void setrating(int k, float rate)
    {
        cmd = new SqlCommand("UPDATE MAIN SET RATING="+rate+" WHERE ID="+k+"", cn);
        cmd.ExecuteNonQuery();
    }

    protected void setwin(int k, int w)
    {
        cmd = new SqlCommand("UPDATE MAIN SET WIN=" + w + " WHERE ID=" + k + "", cn);
        cmd.ExecuteNonQuery();
    }

    protected void setlost(int k, int l)
    {
        cmd = new SqlCommand("UPDATE MAIN SET LOST=" + l + " WHERE ID=" + k + "", cn);
        cmd.ExecuteNonQuery();
    }

    
   

  //  protected void calrating(int m,int n)
  //  {
   //     rating[m] = ((rating[n] + (400 * (votes[m] - votes[n]))) / (votes[m] + votes[n]));   Deprecated Function!!!!  AVOID USING IT.

  //  }
    
    protected void Page_Load(object sender, EventArgs e)
    {

        GridView1.Visible = false;
        if (!IsPostBack)
        {
            cn = new SqlConnection("Data Source = . ; Initial Catalog = FACEMASH2 ; Integrated Security = true ");
            cn.Open();

       //     for (int k = 1; k <= s; k++)
      //      {
     //           cmd = new SqlCommand("INSERT MAIN VALUES(" + k + ",0,0,0)", cn);
     //           cmd.ExecuteNonQuery();
       //     }
            
           // exp = new float[s+1];
          //  rating = new float[s+1];
          //  votes = new int[s+1];
            visited = new int[s+1];
            rand = new Random();

            for (int p = 1; p <= s; p++)
            {
              //  exp[p] = 0;
              //  rating[p] = 0;
            //    votes[p] = 0;
                visited[p] = 0;
            }

            while (i == j)
            {
                i = rand.Next(1, s+1);
                j = rand.Next(1, s+1);
            }


            ImageButton1.ImageUrl = i.ToString() + ".jpg";
            ImageButton2.ImageUrl = j.ToString() + ".jpg";
            Label5.Text = i.ToString();
            Label6.Text = j.ToString();
        }

       
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LOCK = true;
        if (count <= s)
        {
            Response.Write("<script>alert('THANK YOU FOR CASTING')</script>");
            
            win = getwin(i);
            lost = getlost(j);
            gettotalrating(i);
            setwin(i,win+1);
            setlost(j,lost+1);
            lost=getlost(i);
            rating = getrating(j);
            oldrating = getrating(i);
            newrating = oldrating + ( ( rating+(400 * ((win+1) - lost))) / ((win+1) + lost));  //not incliding other's TOTAL RATING=SUM in NEWRATING
            setrating(i, newrating);
            win = getwin(j);
            lost = getlost(j);
            oldrating = getrating(j);
            newrating = oldrating + ((400 * (win - (lost + 1))) / (win + (lost + 1)));     //not incliding other's TOTAL RATING=SUM in NEWRATING
            setrating(j, newrating);

          //  calrating(i, j);
        //    calexp(i, j);

            if (rndm == false)
            {
                visited[l] = j;
                l++;


                count++;


                while (count < s)
                {
                    j = rand.Next(1, s + 1);
                    for (int k = 1; k < l; k++)
                    {
                        if (j == visited[k])
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if ((flag == 1) && (i != j))
                        break;
                    flag = 1;

                }
            }

            if (rndm == true)
            {
                i = j;
                while (i == j)
                {
                    i = rand.Next(1, s + 1);
                    j = rand.Next(1, s + 1);
                }
            }


        }
        if ((flag == 1) && (count == s))
        {
            Response.Write("SORRY, You Have Completed the VOTING PROCESS. PLEASE WAIT FOR NEW PICTURES ");
            
        }

        else if ((flag == 1) && (rndm == true))
        {
            ImageButton2.ImageUrl = j.ToString() + ".jpg";
            ImageButton1.ImageUrl = i.ToString() + ".jpg";
            Label5.Text = i.ToString();
            Label6.Text = j.ToString();
        }
        else if ((flag == 1) && (rndm == false))
        {
            ImageButton2.ImageUrl = j.ToString() + ".jpg";
            Label6.Text = j.ToString();
        }
        else
        {
        }
        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        LOCK = true;
        if (count <= s)
        {
            Response.Write("<script>alert('THANK YOU FOR CASTING')</script>");
            //  votes[j]++;

            win = getwin(j);
            lost = getlost(i);
            gettotalrating(j);
            setwin(j, win + 1);
            setlost(i, lost + 1);
            lost = getlost(j);
            oldrating = getrating(j);
            rating = getrating(i);
            newrating = oldrating + ((rating + (400 * ((win + 1) - lost))) / ((win + 1) + lost));   //not incliding other's TOTAL RATING=SUM in NEWRATING
            setrating(j, newrating);
            win = getwin(i);
            lost = getlost(i);
            oldrating = getrating(i);
            newrating = oldrating + ((400 * (win - (lost + 1))) / (win + (lost + 1)));   //not incliding other's TOTAL RATING=SUM in NEWRATING
            setrating(i, newrating);







            //  calrating(j, i);
            //     calexp(j, i);

            if (rndm == false)
            {

                visited[l] = i;
                l++;
                //     if (count <= s)
                count++;

                while (count < s)
                {
                    i = rand.Next(1, s + 1);
                    for (int k = 1; k < l; k++)
                    {
                        if (i == visited[k])
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if ((flag == 1) && (i != j))
                        break;
                    flag = 1;

                }
            }

            if (rndm == true)
            {
                j = i;
                while (i == j)
                {
                    i = rand.Next(1, s + 1);
                    j = rand.Next(1, s + 1);
                }

            }
            
        }
        if ((flag == 1) && (count == s))
        {
            Response.Write("SORRY, You Have Completed the VOTING PROCESS. PLEASE WAIT FOR NEW PICTURES ");
        }

        else if ((flag == 1) && (rndm == true))
        {
            ImageButton1.ImageUrl = i.ToString() + ".jpg";
            ImageButton2.ImageUrl = j.ToString() + ".jpg";
            Label5.Text = i.ToString();
            Label6.Text = j.ToString();
        }

        else if ((flag == 1) && (rndm == false))
        {
            ImageButton1.ImageUrl = i.ToString() + ".jpg";
            Label5.Text = i.ToString();
        }
        else
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        expi = (float) (1 / (1 + (Math.Pow(10,(getrating(j) - getrating(i)) / 400))));
        expj = (float)(1 / (1 + (Math.Pow(10, (getrating(i) - getrating(j)) / 400))));
        
        Label1.Text = "EXPECTATION is " + expi.ToString();
        Label2.Text = "EXPECTATION is " + expj.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.DataBind();
        GridView1.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (LOCK == false)
        {
            rndm = !(rndm);
            if (rndm == true)
            {
                Button3.Text = "SEQUENTIAL";
                Label4.Text = "RANDOM ORDERING ";
            }

            if (rndm == false)
            {
                Button3.Text = "RANDOM";
                Label4.Text = "SEQUENTIAL ORDERING";
            }
        }

        else
        {
            Response.Write("<script>alert('YOU HAVE ALREADY SELECTED THR ORDERING FOR THIS SESSION')</script>");

        }
    }
}