# Introduction

A playground to try various tech on smart search, google like, improve general product searching possibilities, more connection to brand name, description, search result ranking, search term persistent and analysis, etc.

# Getting Started

Server side app: asp.net core project
Client side app: angular+
Storage: mongoDb text search

# Build and Test

TODO: Might need to import testing data to mongo

# Done

Full text search on description, name. Done
Import data from Trader local DB, product. Done
Fuzzy search on brand, description, name. Done
Deploy to cloud. Done
fuzzy search score, highlights
Auto search suggestion on brand
Client search within brand scope after it's autocompletion, then full text search on description and name

# Notes

Mongo Atlas provider more text search options than mongodb server, like autocomplete, fuzzy.

# TODO

link on img, save the click with search context
NgRx store to trigger link click action, v13 syntax, refer to https://github.com/joshuamorony/ngrx-ionic-example.git
Split Product model and product fuzzy search result
