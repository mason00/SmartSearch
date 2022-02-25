db.product.aggregate(
[
    {
        '$search': {
            'index': 'fuzzy brand', 
            'text': {
                'query': 'supee', 
                'path': [
                    'Brand', 'GenericProductName', 'Description'
                ], 
                'fuzzy': {}
            },
            'highlight': {
                'path': [
                    'Brand', 'GenericProductName', 'Description'
                ]
            }
        }
    },
    {
        '$project': {
            '_id': 1,
            'Description': 1,
            'Brand': 1,
            'GenericProductName': 1,
            'score': {
                '$meta': 'searchScore'
            },
            'highlight': {
                '$meta': 'searchHighlights'
            }
        }
    },
    {
                '$sort': {
                  'score': -1
               }
            }
]
)
    
    
 