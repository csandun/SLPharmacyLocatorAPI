## Sri Lanka *Pharmacies* API with geo codes

Sri Lanka govenment publish a list of **Pharmacies** in srilanka. It published in 2020-03-28. There has more than **1700** pharmacies in islandwide.

The Official web site : [https://pharmacy.health.gov.lk/?fbclid=IwAR3PMS2k2VoigC4ygUyf2d56gTrKrBG2F4mrKOfQrWy4uukiGycy9NO7Vi](https://pharmacy.health.gov.lk/?fbclid=IwAR3PMS2k2VoigC4ygUyf2d56gTrKrBG2F4mrKOfQrWy4uukiGycy9NO7Vi)

Then I grab geo locations from google map according the provided *Addresses*

### There is the API link and sample 

### Link : 
Get: [https://slpharmacylocatorapi.azurewebsites.net/api/pharmacies](https://slpharmacylocatorapi.azurewebsites.net/api/pharmacies)

### Result:
```json
[
  {
    "id": 1,
    "district": "Ampara",
    "name": "Orryngo Pharmacy",
    "address": "Main Street, Addalaichenai",
    "phone": "672277036",
    "whatsApp": "+94772660787",
    "viber": "+94772660787",
    "moH": "Addalaichenai",
    "email": "NULL",
    "latitude": 7.2489373,
    "longitude": 81.8579509
  },
    ...
]

```


