using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int Pow(int baseNum, int exponent) {
        int num = 1;
        for (int i = 0; i < exponent; i++) {
            num *= baseNum;
        }
        return num;
    }

    //去重
    public int[] Deduplicate(int[] nums) {
        return nums.Distinct().ToArray();
    }

    //计算数字长度
    public int Length(int n) {
        if (n < 0) n = Math.Abs(n);
        if (n >= 0 && n < 10) return 1;
        int count = 0;
        while (true) {
            n = n / 10;
            count++;
            if (n == 0) break;
        }
        return count;
    }

    //把数字拆成数组
    public int[] ParseIntToArray(int num) {
        if (num < 0) return new int[] { -1 };
        int[] n = new int[Length(num)];
        int i = 0;
        int m;
        m = num;
        int l = Length(num);
        while (true) {
            n[i] = (int)(m / Math.Pow(10, l - 1 - i));
            m = (int)(m - n[i] * Math.Pow(10, l - 1 - i));
            i++;
            if (Length(m) == 1) {
                n[l - 1] = m;
                break;
            }
        }
        return n;
    }

    public int Reverse(int num) {
        int[] arr = ParseIntToArray(num);
        int[] reverseArr = new int[arr.Length];
        int n = 0;
        for (int i = arr.Length - 1; i >= 0; i--) reverseArr[i] = arr[arr.Length - 1 - i];
        for (int i = 0; i < reverseArr.Length; i++)
            n += Pow(10, reverseArr.Length - 1 - i) * reverseArr[i];
        return n;
    }

    public int MinMirrorPairDistance(int[] nums) {
        //nums=        {12,21,45,6,758,54 };
        //reversedNums={21,12,54,6,758,45 };
        int[] store = new int[nums.Length];
        int count = 0;
        int[] reversedNums = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++) reversedNums[i] = Reverse(nums[i]);
        
        for(int i = 0; i < nums.Length; i++) {
            for(int j = i+1; j < reversedNums.Length; j++) {
                if (nums[j] == Reverse(nums[i]) || (nums[i] >= 0 && nums[i] < 10 && nums[j] == nums[i])){
                    store[count] = j-i;
                    count++;
                }
              //  if (j > i && i >= 0 && Reverse(nums[j]) == nums[i] && Reverse(nums[j]) % 10 == 0) return -1;
            }  
        }
        if (count == 0) return -1;
        // 取前count个有效元素
        int[] v = new int[count];
        for (int i = 0; i < count; i++) v[i] = store[i];
        int[] arr = Deduplicate(v);
        Array.Sort(arr);
        return arr[0];  // 返回最小值

    }

    static void Main(string[] asd) {
        Solution solution = new Solution();
        int i = solution.MinMirrorPairDistance([12, 21, 45, 33, 54]);
        int j = solution.MinMirrorPairDistance([12,210]);
        Console.WriteLine(j);


    }
}
