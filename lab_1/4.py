def plecak(maks_pojemnosc, przedmioty):
    n = len(przedmioty)
    dp = [[0 for _ in range(maks_pojemnosc + 1)] for _ in range(n + 1)]

    for i in range(1, n + 1):
        waga, wartosc = przedmioty[i - 1]
        for w in range(1, maks_pojemnosc + 1):
            if waga <= w:
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - waga] + wartosc)
            else:
                dp[i][w] = dp[i - 1][w]

    return dp[n][maks_pojemnosc]

# Przykład
przedmioty = [(2, 3), (3, 4), (4, 5), (5, 8)]
maks_pojemnosc = 5
print(plecak(maks_pojemnosc, przedmioty))
