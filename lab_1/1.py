def podzial_paczek(paczki, maks_waga):
    paczki.sort(reverse=True)  # Sort by descending weight
    trips = []
    current_trip = []

    for paczka in paczki:
        if sum(current_trip) + paczka <= maks_waga:
            current_trip.append(paczka)
        else:
            trips.append(current_trip)
            current_trip = [paczka]
    
    if current_trip:
        trips.append(current_trip)
    
    return len(trips), trips

# Przykład
paczki = [10, 8, 7, 5, 3, 1]
maks_waga = 15
print(podzial_paczek(paczki, maks_waga))
