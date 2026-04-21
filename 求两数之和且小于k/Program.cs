public class Solution {
    // 判断 target 是否是数组中的最小值
    public bool IsMinValue(int[] arr, int target) {
        if (arr == null || arr.Length == 0) return false;

        int min = arr[0];
        for (int i = 1; i < arr.Length; i++) {
            if (arr[i] < min) {
                min = arr[i];
            }
        }
        return min == target;
    }

    public int TwoSumLessThanK(int[] nums, int k) {
        // 计算所有两数之和
        int totalPairs = nums.Length * (nums.Length - 1) / 2;
        int[] sums = new int[totalPairs];
        int index = 0;

        // 收集所有不重复的两数之和
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                sums[index++] = nums[i] + nums[j];
            }
        }

        // 收集所有小于 k 的和，并计算差值
        int[] validSums = new int[totalPairs];
        int[] diffs = new int[totalPairs];
        int validCount = 0;

        for (int i = 0; i < totalPairs; i++) {
            if (sums[i] < k) {
                validSums[validCount] = sums[i];
                diffs[validCount] = k - sums[i];
                validCount++;
            }
        }

        // 如果没有找到符合条件的和
        if (validCount == 0) return -1;

        // 截取有效部分
        int[] finalDiffs = new int[validCount];
        int[] finalSums = new int[validCount];
        for (int i = 0; i < validCount; i++) {
            finalDiffs[i] = diffs[i];
            finalSums[i] = validSums[i];
        }

        // 找到最小差值对应的和（最接近 k）
        int minDiff = finalDiffs[0];
        int minDiffIndex = 0;
        for (int i = 1; i < validCount; i++) {
            if (finalDiffs[i] < minDiff) {
                minDiff = finalDiffs[i];
                minDiffIndex = i;
            }
        }

        return finalSums[minDiffIndex];
    }

    static void Main(string[] args) {
        Solution e = new Solution();
        int w = e.TwoSumLessThanK(new int[] { 34, 23, 1, 24, 75, 33, 54, 8 }, 60);
        Console.WriteLine(w);  // 输出: 58
    }
}