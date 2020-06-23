using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsSeleniumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new EdgeDriver())
            {
                // URLを取得
                driver.Url = @"https://qiita.com/login?redirect_to=%2F";

                // ログイン名（メールアドレス）を入力
                IWebElement element = driver.FindElement(By.Id("identity"));
                element.SendKeys("mail address");

                // パスワード名を入力
                element = driver.FindElement(By.Id("password"));
                element.SendKeys("password");

                // ログインボタンをクリック
                element = driver.FindElement(By.Name("commit"));
                element.Click();

                // 1秒待機
                Thread.Sleep(TimeSpan.FromSeconds(1));

                // 1日のトレンド記事をまとめて取得
                List<IWebElement> elements = driver.FindElements(By.ClassName("tr-Item_title")).ToList();

                // 記事のタイトルをコンソールに表示
                foreach(IWebElement ele in elements)
                {
                    Console.WriteLine(ele.Text);
                }

                // ブラウザを閉じる
                driver.Quit();
                
            }
            Console.ReadKey();
        }
    }
}
