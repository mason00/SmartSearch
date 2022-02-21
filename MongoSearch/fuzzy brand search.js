db.product.aggregate(
[
    {
        '$search': {
            'index': 'fuzzy brand', 
            'text': {
                'query': 'supee', 
                'path': [
                    'Brand'
                ], 
                'fuzzy': {}
            }, 
            'highlight': {
                'path': 'Brand'
            }
        }
    }, {
        '$project': {
            'highlight': {
                '$meta': 'searchHighlights'
            }, 
            'Brand': 1
        }
    }
]
  )
    
    
 