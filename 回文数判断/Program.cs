namespace IsPalindrome {
public class Solution {
    public static int length(int num) {
        if (num < 0) return -1;
        if (num < 10) return 1;
        int count = 0;
        while (true) {
            num = num / 10;
            count++;
            if (num == 0) return count;
        }
    }
    public static int[] parseIntToArray(int num) {
        if (num < 0) return new int[] { -1 };  
        int[] n = new int[length(num)];
        int i = 0;
        int m;
        m = num;
        int sum = 0;
        int l = length(num);
        while (true) {
            n[i] = (int)(m / (Math.Pow(10, l - 1 - i)));
            m = (int)(m - n[i] * Math.Pow(10, l - 1 - i));
            i++;
            if (length(m) == 1) {
                n[l - 1] = m;
                break;
            }
        }
        return n;
    }
    public static bool IsPalindrome(int x) {
        int[] nums = parseIntToArray(x);
        int[] reversedNums=new int[nums.Length]; 
        int n = 0;int m = 0;
        for(int i = 0; i < nums.Length; i++) n = (int)(nums[i] * Math.Pow(10, nums.Length-1-i));
        for(int i =0;i<nums.Length;i++) reversedNums[i] = nums[nums.Length-1-i];
        for(int i=0;i<reversedNums.Length;i++) m=(int)(reversedNums[i] * Math.Pow(10, nums.Length - 1 - i));

        if (n == m) return true;
        else return false;
    }
    static void Main() {
        Console.WriteLine(IsPalindrome(41));
        Console.WriteLine(IsPalindrome(74547));
    }
}
}
