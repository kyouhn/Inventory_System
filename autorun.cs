using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace autopurchase_at_ranking
{
   
    class autorun
    {
        public static string sql_Load(string sqlcode, string data)
        {

            OleDbDataReader dr = null;
            OleDbCommand cmd = null;

            using (OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd = new OleDbCommand(sqlcode, cn);
                    dr = cmd.ExecuteReader();

                    dr.Read();
                    return dr[data].ToString();
                }
                catch
                {
                    //error
                    return "";
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }
        }
        private static int sql_Load_2(string sqlcode, string data, string[] bukkomi)
        {
            int k = 0;
            OleDbDataReader dr = null;
            OleDbCommand cmd = null;
            using (OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd = new OleDbCommand(sqlcode, cn);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bukkomi[k] = dr[data].ToString();

                        k++;
                    }
                    return k - 1;


                }
                catch (Exception ex)
                {
                    //error_Disp(ex.ToString());
                    return -1;
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }

        }//sqlcodeに打ち込んだSQL文でdataの内容を返す
        private static int sql_Write(string sqlcode)
        {
            int cnt = 0;
            OleDbDataReader dr = null;
            OleDbCommand cmd = null;
            using (OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString))
            {
                try
                {
                    cmd = new OleDbCommand(sqlcode, cn);
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    cnt = cmd.ExecuteNonQuery();
                    return 0;
                }

                catch (Exception ex)
                {
                    return -1;
                    //error
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }

        public void auto()
        {

        }

        public static void Run()
        {
            try
            {

                DateTime time = DateTime.Now;
                DateTime time2 = time.AddDays(-7);
                string day = time.ToString("yyyy/MM/dd");
                short pur_threshold_num_first = 3;//ランキング用の順位MASID頭の数
                short pur_threshold_num_last = 8;//ランキング用の順位MASID尻の数
                int pur_threshold_num = (pur_threshold_num_last - pur_threshold_num_first) + 1;
                string[] proid = new string[100000];
                string[] stock = new string[100000];
                int count_PROID = 0;//変更件数
                int count_STOCK = 0;//変更件数
                string[] temp = new string[256];
                string[] temp2 = new string[256];
                int[] pur_threshold = new int[pur_threshold_num];
                int[] pur_threshold_2 = new int[pur_threshold_num];
                pur_threshold[0] = 1000;
                int purorder_num = 12;
                int nextaddno = 0;
                int parcent = 0;

                Console.WriteLine(
                    "+- - - - - - - - - - - - - - - - - - -+" + System.Environment.NewLine +
                    "*                                     *" + System.Environment.NewLine +
                    "*     AUTOMATIC  ORDERING  SYSTEM     *" + System.Environment.NewLine +
                    "*                                     *" + System.Environment.NewLine +
                    "+- - - - - - - - - - - - - - - - - - -+" + System.Environment.NewLine +
                    "日時:" + day + System.Environment.NewLine
                                    );
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("自動発注処理を開始します" + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                //閾値読み込み
                System.Threading.Thread.Sleep(250);
                /*
                Console.WriteLine("debug:dbを他アプリで開いてないのを確認後、続行時はEnter押下");
                Console.ReadLine();
                //*/

                Console.WriteLine("[1/9]:閾値読込" + System.Environment.NewLine);
                sql_Load_2("SELECT MASINFO1 FROM MASTER WHERE MASID>=" + pur_threshold_num_first + " AND MASID <=" + pur_threshold_num_last + "", "MASINFO1", temp);
                sql_Load_2("SELECT MASINFO2 FROM MASTER WHERE MASID>=" + pur_threshold_num_first + " AND MASID <=" + pur_threshold_num_last + "", "MASINFO2", temp2);
                Console.WriteLine("読み込み完了しました。" + System.Environment.NewLine + System.Environment.NewLine + "閾値一覧");
                for (int i = 0; i <= pur_threshold_num - 1; i++)
                {
                    Console.Write("閾値" + (i + 1).ToString() + ":");
                    pur_threshold[i] = int.Parse(temp[i]);
                    Console.Write(temp[i] + ",");
                    pur_threshold_2[i] = int.Parse(temp2[i]);
                    Console.Write(temp2[i] + "  ");
                }
                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                //全体用閾値以下一括変更
                //Console.WriteLine("最低閾値以下の商品絞込＆変更" + System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("[2/9]:自動発注商品絞り込みを開始します");
                Console.WriteLine("在庫数がランキング外の閾値を下回っている商品を絞り込みます" + System.Environment.NewLine +
                    System.Environment.NewLine + "-商品ID-                     -在庫数-");


                count_PROID = sql_Load_2("SELECT PROID,STOCK FROM STOCK WHERE STOCK < " + pur_threshold[pur_threshold_num - 1].ToString() + " ORDER BY PROID,STOCK", "PROID", proid);
                count_STOCK = sql_Load_2("SELECT PROID,STOCK FROM STOCK WHERE STOCK < " + pur_threshold[pur_threshold_num - 1].ToString() + " ORDER BY PROID,STOCK", "STOCK", stock);

                //*発注必要商品の表示
                try
                {
                    for (int i = 0; i <= count_PROID; i++)
                    {
                        Console.WriteLine(proid[i] + " , " + stock[i]);
                    }
                }
                catch { }
                finally { }
                //*/
                Console.WriteLine(System.Environment.NewLine + "計" + (count_PROID + 1).ToString() + "件ヒットしました" + System.Environment.NewLine);

                //while (true) { }
                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                int l = 0;
                int j = 0;
                int error = 0;
                parcent = 0;
                Console.WriteLine("[3/9]発注リストに追加します。");
                try
                {
                    while (count_PROID >= l)
                    {

                        error = sql_Write("INSERT INTO PURCHASE(PURID,PURDAY) VALUES ('" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "','" + day + "')");
                        Console.CursorLeft = 0;
                        parcent = (l * 100) / count_PROID;
                        //*
                        if (error != 0)
                        {
                            Console.Write("                                          ");
                            Console.CursorLeft = 0;
                            Console.Write("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー" + Environment.NewLine + Environment.NewLine);
                        }
                        //*/
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("-");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: " + parcent.ToString() + "%");
                        l++;
                    }

                }
                catch
                {
                    Console.WriteLine("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                    "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +
                                    System.Environment.NewLine + "ErrorCode:00001");
                }
                finally { }

                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                l = 0;
                j = 0;
                error = 0;
                Console.WriteLine("[4/9]:発注明細リストに追加します。");
                try
                {
                    int k = 0;
                    while (count_PROID >= j)
                    {
                        k = int.Parse(sql_Load("SELECT MAX(PURDETID) AS PURDETID FROM PURCHASEDETAIL", "PURDETID"));
                        error = sql_Write("INSERT INTO PURCHASEDETAIL(PURDETID,PURID,PROID,PURPIECE) VALUES ('" + String.Format("{0:00000000}", k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1)) + "','" + proid[j] + "'," + purorder_num + ")");
                        Console.CursorLeft = 0;
                        parcent = (l * 100) / count_PROID;
                        //*
                        if (error != 0)
                        {
                            Console.Write("                                          ");
                            Console.CursorLeft = 0;
                            Console.Write("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー" + Environment.NewLine + Environment.NewLine);
                        }
                        //*/
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("-");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: " + parcent.ToString() + "%");
                        j++;
                        k++;
                        l++;
                    }


                }
                catch
                {
                    Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                    System.Threading.Thread.Sleep(250);
                    Console.WriteLine("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                    "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +
                                    System.Environment.NewLine + "ErrorCode:00001");
                }
                finally { }
                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                l = 0;
                j = 0;
                error = 0;
                Console.WriteLine("[5/9]:入庫確定リストに入庫予定を追加します。");
                try
                {
                    int k = 0;
                    while (count_PROID >= j)
                    {
                        k = int.Parse(sql_Load("SELECT MAX(RECID) AS RECID FROM RECEIVE", "RECID"));
                        error = sql_Write("INSERT INTO RECEIVE(RECID,PURID,RECDAY,RECDAYPLAN) VALUES ('" + String.Format("{0:0000000}", k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1)) + "',null,'" + time.ToString("yyyy/MM/dd") + "')");
                        Console.CursorLeft = 0;
                        parcent = (l * 100) / count_PROID;
                        if (error != 0)
                        {

                            Console.Write("                                          ");
                            Console.CursorLeft = 0;
                            Console.Write("商品ID[" + proid[j] + "]:エラー" + Environment.NewLine + Environment.NewLine);
                        }
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("-");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: " + parcent.ToString() + "%");
                        j++;
                        k++;
                        l++;
                    }
                    nextaddno = j - 1;

                }
                catch
                {
                    Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                    System.Threading.Thread.Sleep(250);
                    Console.WriteLine("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                    "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +
                                    System.Environment.NewLine + "ErrorCode:00001");
                }
                finally { }
                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                //在庫が最低閾値以下の商品発注が完了
                //次はランキングからproid引っ張ってきて格納
                //それと上で一括変更したproid変数をそれぞれ比較
                //一致するものがあったら除外して
                //なかったら新しいproid配列に追加
                //上の処理をもう一度繰り返して
                //発注処理完了
                //RECEIVEテーブルとかもろもろのPURIDは全部null非許可に変更しておく
                string[] proid_Rankin_temp = new string[100000];
                string[] stock_Rankin_temp = new string[100000];
                string[] proid_Rankin = new string[100000];
                string[] stock_Rankin = new string[100000];
                string[] Rank_Rankin_string = new string[100000];
                int count_PROID_Rankin = 0;//変更件数
                int count_STOCK_Rankin = 0;//変更件数
                int count_RANK_Rankin = 0;//変更件数
                bool flag = false;

                //全体用閾値以下一括変更
                //Console.WriteLine("(ランクイン商品)閾値以下の商品絞込＆変更" + System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("[6/9]:(ランクイン商品)自動発注商品絞り込みを開始します");
                Console.WriteLine("在庫数がランキング外の閾値を下回っている商品を絞り込みます" + System.Environment.NewLine +
                Environment.NewLine + "-商品ID-                    -在庫数-");

                //sql_Load2(%1,%2,%3)の%1に
                //上から順番に
                //ランキング上位10位絞り込みした
                //1,商品コードPROID
                //2.在庫数STOCK
                //3.順位(%2には順位の列名)
                //を入れる
                //10位までを絞り込む所までがSQL文

                //ランキング
                string[] temp999 = new string[9999999];
                string[] temp998 = new string[9999999];
                string temp001 = "";
                //8日前の年月日を取得
                int[] temp100 = new int[3];
                temp100[0] = int.Parse(time2.AddDays(-1).ToString("yyyy"));
                temp100[1] = int.Parse(time2.AddDays(-1).ToString("MM"));
                temp100[2] = int.Parse(time2.AddDays(-1).ToString("dd"));
                //deal,deadayを全部上り順で取得
                sql_Load_2("select deaday from deal order by deaday", "deaday", temp999);
                int temp000 = sql_Load_2("select deaid from deal order by deaid", "deaid", temp998);
                //取得した値の数だけ変数を作成
                int[] temp101 = new int[temp000 + 1];
                int[] temp102 = new int[temp000 + 1];
                int[] temp103 = new int[temp000 + 1];
                //時間を省略したものと年月日を分離したものを用意
                for (int i = 0; i < temp000; i++)
                {
                    temp999[i] = DateTime.Parse(temp999[i]).ToString("yyyy/MM/dd");
                    temp101[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("yyyy"));
                    temp102[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("MM"));
                    temp103[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("dd"));
                }
                //7日前の一番若いdeaidを取得
                try
                {
                    bool loopflag2 = false;
                    for (int i = 0; loopflag2 != true; i++)
                    {
                        //日が8日前以上 もしくは 月が8日前より大きいか比較
                        if (temp103[i] >= temp100[2] || temp102[i] > temp100[1])
                        {
                            //月が8日前以上 もしくは 年が8日前より大きいか比較
                            if (temp102[i] >= temp100[1] || temp101[i] > temp100[0])
                            {
                                //年が8日前以上か比較
                                if (temp101[i] >= temp100[0])
                                {
                                    temp001 = temp998[i + 1];
                                    loopflag2 = true;
                                }
                            }
                        }
                    }
                }
                catch { }
                finally { }
                //なんやかんやあってtemp001が7日前最小のdeaid

                //一週間の商品とその売り上げ一覧（商品コードで並び替え）
                string[] temp201 = new string[1000000];
                int temp211 = 0;
                string[] temp202 = new string[1000000];

                temp211 = sql_Load_2("SELECT PROID,ORDPIECE FROM DETAIL WHERE PROID >= '0000047' ORDER BY PROID;", "PROID", temp201);
                sql_Load_2("SELECT PROID,ORDPIECE FROM DETAIL WHERE PROID >= '0000047' ORDER BY PROID;", "ORDPIECE", temp202);

                //商品ごとの売り上げにまとめる
                string[] temp221 = new string[1000000];
                int[] temp222 = new int[1000000];
                int temp212 = -1;
                string temptemptemp = "";
                for (int i = 0; i < temp211; i++)
                {
                    if (temptemptemp != temp201[i])
                    {//直前の商品コードと別の場合(新規変数にそれ追加)
                        temp212++;
                        temp221[temp212] = temptemptemp = temp201[i];
                        temp222[temp212] = int.Parse(temp202[i]);
                    }
                    else
                    {//直前の商品コードと同じ場合(既存変数に個数だけを追加)
                        temp222[temp212] += int.Parse(temp202[i]);
                    }
                }
                temp212++;

                //完成したものを売上個数多い順に並び替える
                string temp291 = "";
                int temp292 = 0;

                for (int i = 0; i < temp212 - 1; i++)
                {
                    if (temp222[i] < temp222[i + 1])
                    {
                        temp292 = temp222[i];
                        temp291 = temp221[i];

                        temp222[i] = temp222[i + 1];
                        temp221[i] = temp221[i + 1];

                        temp222[i + 1] = temp292;
                        temp221[i + 1] = temp291;

                        i = -1;
                    }
                }

                //ランキングと比較して自動発注かけるやつをピックアップ
                string[] temp231 = new string[100000];
                int[] temp232 = new int[100000];
                bool loopflag = false;
                l = 0;//直近の個数
                j = 0;//更新件数
                int h = 0;//直近のランキング順位を一時格納
                try
                {
                    for (int i = 0; loopflag != true; i++)
                    {
                        if (temp222[i] != l)
                        {
                            switch (i)
                            {
                                case 1 - 1:
                                    {
                                        if (temp222[i] <= pur_threshold[0])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = i;
                                        }
                                        break;
                                    }
                                case 2 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[1])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = i;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 3 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[2])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = i;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 4 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[3])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = i;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 5 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[4])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = 4;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 6 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[4])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = 4;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 7 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[4])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = 4;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 8 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[4])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = 4;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 9 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[4])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = 4;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 10 - 1:
                                    if (temp222[i] != l)
                                    {//
                                        if (temp222[i] <= pur_threshold[4])
                                        {
                                            temp231[j] = temp221[i];
                                            l = temp232[j] = temp222[i];
                                            j++;
                                            h = 4;
                                        }
                                        else
                                        {
                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        if (temp222[i] == l)
                                        {//

                                            if (temp222[i] <= pur_threshold[h])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                            }
                                            else
                                            {
                                                loopflag = true;
                                                break;
                                            }
                                        }
                                    }
                                    break;
                            }

                        }
                    }
                }
                catch { }
                finally { }


                //strSQL5 = "SELECT DETAIL.[PROID], Sum(DETAIL.[ORDPIECE]) AS ORDPIECE FROM DETAIL 'GROUP BY DETAIL.[PROID] order by Sum(DETAIL.[ORDPIECE]) desc ";
                //10位までループ
                //以降10位の在庫数と同じまでループ

                for (int i = 0; i <= 1000; i++)
                {
                    proid_Rankin[i] = temp231[i];
                    stock_Rankin[i] = temp232[i].ToString();
                }


                //count_PROID_Rankin = sql_Load_2("SELECT DETAIL.PROID AS PROID, Sum(DETAIL.ORDPIECE) AS SUM FROM DEAL INNER JOIN DETAIL ON DEAL.DEAID = DETAIL.DEAID WHERE(((DETAIL.DEAID) >= "+'"'+ temp001 + '"'+")) GROUP BY DETAIL.PROID ORDER BY Sum(DETAIL.ORDPIECE) DESC;", "SUM", proid_Rankin_temp);



                //*発注必要商品の表示
                try
                {
                    for (int i = 0; i <= count_PROID_Rankin; i++)
                    {
                        Console.WriteLine(proid_Rankin[i] + " , " + stock_Rankin[i]);
                    }
                }
                catch { }
                finally { }
                //*/
                Console.WriteLine(System.Environment.NewLine + "計" + (count_PROID_Rankin + 1).ToString() + "件ヒットしました" + System.Environment.NewLine);

                //while (true) { }
                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                l = 0;
                j = 0;
                error = 0;
                Console.WriteLine("[7/9]:(ランクイン商品)発注リストに追加します。");
                try
                {
                    while (count_PROID_Rankin >= l)
                    {

                        error = sql_Write("INSERT INTO PURCHASE(PURID,PURDAY) VALUES ('" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1 + nextaddno)) + "','" + day + "')");
                        Console.CursorLeft = 0;
                        parcent = (l * 100) / count_PROID;
                        /*
                        if (error != 0)
                        {
                            Console.Write("                                          ");
                            Console.CursorLeft = 0;
                            Console.Write("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー" + Environment.NewLine + Environment.NewLine);
                        }
                        //*/
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("-");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: " + parcent.ToString() + "%");
                        l++;
                    }

                }
                catch
                {
                    Console.WriteLine("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                    "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +
                                    System.Environment.NewLine + "ErrorCode:00001");
                }
                finally {
                    Console.CursorLeft = 0;
                    Console.Write("[");
                    for (int i = 0; i < 100; i += 4)
                    {

                        if (parcent - i > 0)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write("#");
                        }


                    }
                    Console.Write("]");
                    Console.Write(" 進行状況: 100%");
                }

                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                l = 0;
                j = 0;
                error = 0;
                Console.WriteLine("[8/9]:(ランクイン商品)発注明細リストに追加します。");
                try
                {
                    int k = 0;
                    while (count_PROID_Rankin >= j)
                    {
                        k = int.Parse(sql_Load("SELECT MAX(PURDETID) AS PURDETID FROM PURCHASEDETAIL", "PURDETID"));
                        error = sql_Write("INSERT INTO PURCHASEDETAIL(PURDETID,PURID,PROID,PURPIECE) VALUES ('" + String.Format("{0:00000000}", k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1 + nextaddno)) + "','" + proid_Rankin[j] + "'," + purorder_num + ")");
                        Console.CursorLeft = 0;
                        parcent = (l * 100) / count_PROID;
                        /*
                        if (error != 0)
                        {
                            Console.Write("                                          ");
                            Console.CursorLeft = 0;
                            Console.Write("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー" + Environment.NewLine + Environment.NewLine);
                        }
                        //*/
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("-");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: " + parcent.ToString() + "%");
                        l++;
                        j++;
                        k++;
                    }

                }
                catch
                {
                    Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                    System.Threading.Thread.Sleep(250);
                    Console.WriteLine("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                    "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +
                                    System.Environment.NewLine + "ErrorCode:00001");
                }
                finally
                {
                    Console.CursorLeft = 0;
                    Console.Write("[");
                    for (int i = 0; i < 100; i += 4)
                    {

                        if (parcent - i > 0)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write("#");
                        }


                    }
                    Console.Write("]");
                    Console.Write(" 進行状況: 100%");
                }
                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                l = 0;
                j = 0;
                error = 0;
                Console.WriteLine("[9/9]:(ランクイン商品)入庫確定リストに入庫予定を追加します。");
                try
                {
                    int k = 0;
                    while (count_PROID_Rankin >= j)
                    {
                        k = int.Parse(sql_Load("SELECT MAX(RECID) AS RECID FROM RECEIVE", "RECID"));
                        error += sql_Write("INSERT INTO RECEIVE(RECID,PURID,RECDAY,RECDAYPLAN) VALUES ('" + String.Format("{0:0000000}", k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1 + nextaddno)) + "',null,'" + time.ToString("yyyy/MM/dd") + "')");
                        Console.CursorLeft = 0;
                        parcent = (l * 100) / count_PROID;
                        /*
                        if (error != 0)
                        {
                            Console.Write("                                          ");
                            Console.CursorLeft = 0;
                            Console.Write("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー" + Environment.NewLine + Environment.NewLine);
                        }
                        //*/
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("-");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: " + parcent.ToString() + "%");
                        l++;
                        j++;
                        k++;
                    }

                }
                catch
                {
                    Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                    System.Threading.Thread.Sleep(250);
                    Console.WriteLine("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                    "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +
                                    System.Environment.NewLine + "ErrorCode:00001");
                }
                finally
                {
                    Console.CursorLeft = 0;
                    Console.Write("[");
                    for (int i = 0; i < 100; i += 4)
                    {

                        if (parcent - i > 0)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write("#");
                        }


                    }
                    Console.Write("]");
                    Console.Write(" 進行状況: 100%");
                }

                //
                //
                //

                Console.Write(System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                System.Threading.Thread.Sleep(250);
                //Console.WriteLine("自動発注処理が完了しました。" + System.Environment.NewLine + "この画面を閉じるには何かキーを押してください。");

                sql_Write("UPDATE MASTER SET MASINFO1='" + ((DateTime.Parse(sql_Load("SELECT MASINFO1 FROM MASTER WHERE MASID=9", "MASINFO1"))).AddDays(7)).ToString("yyyy/MM/dd") + "' WHERE MASID=9");

                //* ↓コメント化で画面が閉じて自動でreturn0を返す
                //　↖の「//*」を「/*」みたいにスラッシュ一個つけたり
                //   消したりするだけでコメント化するかどうか変更できるよ
               // Console.ReadKey();
                //*/

                //return 0;
            }
            catch
            {
             //   Console.Write(System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine +
             //       "致命的なエラーが発生しました。データベースファイルがあるかどうかを確認してください。");
                //return -1;
            }
            finally
            {

            }
        }
    }
}

