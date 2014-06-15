using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hitter hitter = new Hitter();
            string[] hitters = new string[9] { "민병헌", "오재원", "김현수", "칸투", "홍성흔", "양의지", "이원석", "김재호", "정수빈" };
            hitter.NameOfPitcher = "장원삼";
            hitter.grade = 3;
            for (int i = 0; i <= hitters.Length - 1; i++)
            {
                hitter.NameOfHitter = hitters[i];
                hitter.Match(hitter.NameOfHitter, hitter.NameOfPitcher, hitter.grade);
            }
        }
    }
    class Hitter
    {
        public string NameOfHitter;
        public string NameOfPitcher;
        public int grade;
        public void Match(string NameOfHitter, string NameOfPitcher, int grade)
        {
            Random ball = new Random();
            int S = 0;
            int B = 0;
            int O = 0;
            for (int NumberOfPitched = 1; O < 3; NumberOfPitched++)
            {
                int a = ball.Next(1, 20 / grade);
                int b = ball.Next(1, 20 / grade);
                Console.WriteLine(a);
                Console.Write("Hit or Wait?: ");
                string HitOrWait = Console.ReadLine();
                if (a >= 1 && a <= 20 / grade / 3)
                {
                    if (HitOrWait == "H")
                    {
                        if (a == b)
                        {
                            Console.WriteLine("{0} 선수 {1} 상대로 안타를 뽑아냅니다!", NameOfHitter, NameOfPitcher);
                            S = 0;
                            B = 0;
                            PrintBallCount(S, B, O, NumberOfPitched);
                        }
                        else
                        {
                            Console.WriteLine("{0} 헛스윙!", NameOfHitter);
                            if (S >= 2)
                            {
                                Console.WriteLine("삼진!");
                                O++;
                                S = 0;
                                B = 0;
                                PrintBallCount(S, B, O, NumberOfPitched);
                                break;
                            }
                            else
                            {
                                S++;
                                PrintBallCount(S, B, O, NumberOfPitched);
                            }
                        }
                    }
                    else if (HitOrWait == "W")
                    {
                        Console.WriteLine("{0} 선수, 스트라이크를 쳐다만 보고 있네요.", NameOfHitter);
                        if (S >= 2)
                        {
                            Console.WriteLine("루킹 삼진!");
                            O++;
                            S = 0;
                            B = 0;
                            PrintBallCount(S, B, O, NumberOfPitched);
                            break;
                        }
                        else
                        {
                            S++;
                            PrintBallCount(S, B, O, NumberOfPitched);
                        }
                    }
                    else
                    {
                        Console.WriteLine("치거나 기다리거나 둘 중 하나만 하세요.");
                    }
                }
                else
                {
                    if (HitOrWait == "H")
                    {
                        if (a == b)
                        {
                            Console.WriteLine("{0} 선수, 파울로 잘 커트했네요.", NameOfHitter);
                            if (S <= 2)
                            {
                                S++;
                            }
                            PrintBallCount(S, B, O, NumberOfPitched);
                        }
                        else
                        {
                            Console.WriteLine("{0}, 저런 볼에 배트가 나오면 안 되죠", NameOfHitter);
                            if (S >= 2)
                            {
                                Console.WriteLine("헛스윙 삼진!");
                                O++;
                                S = 0;
                                B = 0;
                                PrintBallCount(S, B, O, NumberOfPitched);
                                break;
                            }
                            else
                            {
                                S++;
                                PrintBallCount(S, B, O, NumberOfPitched);
                            }
                        }
                    }
                    else if (HitOrWait == "W")
                    {
                        Console.WriteLine("{0} 선수 잘 참아내네요.", NameOfHitter);
                        if (B >= 3)
                        {
                            Console.WriteLine("볼넷으로 출루합니다!");
                            S = 0;
                            B = 0;
                            PrintBallCount(S, B, O, NumberOfPitched);
                            break;
                        }
                        else
                        {
                            B++;
                            PrintBallCount(S, B, O, NumberOfPitched);
                        }
                    }
                    else
                    {
                        Console.WriteLine("치거나 기다리거나 둘 중 하나만 하세요.");
                    }
                }
            }
        }
        static void PrintBallCount(int S, int B, int O, int NumberOfPitched)
        {
            Console.WriteLine("투구수: {0}", NumberOfPitched);
            Console.Write("S ");
            for (int s = 1; s <= S; s++)
            {
                Console.Write("●");
            }
            Console.WriteLine();
            Console.Write("B ");
            for (int b = 1; b <= B; b++)
            {
                Console.Write("●");
            }
            Console.WriteLine();
            Console.Write("O ");
            for (int o = 1; o <= O; o++)
            {
                Console.Write("●");
            }
            Console.WriteLine();
        }
        static void PrintBase()
        {
            // 주자 출루한 것을 보여줌.
        }
    }
    class Pitcher
    {
        public string NameOfPitcher;
        public int grade;
    }
}
