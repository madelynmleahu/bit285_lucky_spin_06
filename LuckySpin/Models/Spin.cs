using System;
namespace LuckySpin.Models
{
    public class Spin
    {
        public long Id { get; set; }
        public int Luck { get; set; }
        public Boolean IsWinning { get; set; }
    }
}
