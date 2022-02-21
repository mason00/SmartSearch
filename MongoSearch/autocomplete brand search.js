

db.brand.aggregate(
[
  {
    $search: {
      index: 'default',
      autocomplete: {
        query: 'lova',
        path: 'BrandName',
        fuzzy: { maxEdits: 1, prefixLength: 0 }
      },
      highlight: { 
        path: "BrandName"
      }
    }
  },
  {
      $project: {
           _id: 1,
                  BrandName: 1,
                  highlights: { $meta: 'searchHighlights' },
                  Score: { $meta: 'searchScore' },
     }
  },
  {
                $sort: {
                  score: 1
               }
            }
]
)