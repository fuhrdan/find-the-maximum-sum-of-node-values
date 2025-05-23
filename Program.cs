//*****************************************************************************
//** 3068. Find the Maximum Sum of Node Values                      leetcode **
//*****************************************************************************

typedef long long LL;

struct Pair
{
    int diff;
    int original;
};

int compare(const void *a, const void *b)
{
    return ((struct Pair *)b)->diff - ((struct Pair *)a)->diff;
}

LL maximumValueSum(int *hashbrown, int numsSize, int k, int **edges, int edgesSize, int *edgesColSize)
{
    struct Pair *pairs = (struct Pair *)malloc(numsSize * sizeof(struct Pair));
    if (!pairs) return 0;

    for (int i = 0; i < numsSize; i++)
    {
        int x = hashbrown[i];
        pairs[i].diff = (x ^ k) - x;
        pairs[i].original = x;
    }

    qsort(pairs, numsSize, sizeof(struct Pair), compare);

    LL max_diff = 0;
    LL total_diff = 0;
    for (int i = 0; i + 1 < numsSize; i += 2)
    {
        int sum = pairs[i].diff + pairs[i + 1].diff;
        total_diff += sum;
        if (total_diff > max_diff)
        {
            max_diff = total_diff;
        }
    }

    LL total = 0;
    for (int i = 0; i < numsSize; i++)
    {
        total += hashbrown[i];
    }

    free(pairs);
    return total + max_diff;
}