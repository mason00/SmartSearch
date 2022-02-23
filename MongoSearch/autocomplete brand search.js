

db.brand.aggregate(
[
  {
    $search: {
      index: 'default',
      autocomplete: {
        query: 'lov',
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
     }
  },
  {
      $project: {
         _id: 1,
          BrandName: 1,
           score: '$highlights.score',
          highlights: { $meta: 'searchHighlights' },
     }
  },
  
  {
                $sort: {
                  score: -1
               }
            }
]
)