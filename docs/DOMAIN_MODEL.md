# Thailand Companion Domain Model

## Purpose

The Domain Model defines the core business objects used throughout Thailand Companion.

It is intentionally independent of the database, API, and frontend.

The goal is to describe **what the application is**, not **how it is implemented**.

---

# Administrative Areas vs Physical Locations

Thailand Companion separates official geographic divisions from real-world places.

## Administrative Areas

Administrative Areas are official Thailand geographic divisions.

Thailand
↓
Province
↓
District
↓
Subdistrict

These are used for organizing data, filtering, URLs, and search.

## Physical Locations

A Location is a real-world place someone can visit, view on a map, review, or associate with content.

Examples:

- Cha-am Beach
- Hua Hin Hospital
- Cicada Market
- A house for sale
- A coffee shop
- Immigration Office

Locations belong to a Subdistrict.

Properties, Points of Interest, Videos, and Reviews connect to Locations.

# Vision

Thailand Companion is not a property website.

Thailand Companion is a platform that helps people:

* Explore Thailand
* Move to Thailand
* Live in Thailand

Everything within the application revolves around **Locations**.

Properties are only one type of information connected to a location.

---

# Core Domain

```
Thailand
    │
    ▼
Province
    │
    ▼
District
    │
    ▼
Subdistrict
    │
    ▼
Location
```

Every object in the system eventually relates to a Location.

---

# Thailand

Represents the country.

Contains all Provinces.

---

# Province

Examples:

* Bangkok
* Chiang Mai
* Prachuap Khiri Khan
* Phuket

A Province contains many Districts.

---

# District

Examples:

* Hua Hin
* Cha-am
* Mueang Phuket

A District belongs to one Province.

A District contains many Subdistricts.

---

# Subdistrict

Represents the smallest administrative area used by Thailand Companion.

A Subdistrict belongs to one District.

A Subdistrict contains many Locations.

---

# Location

The Location object is the foundation of Thailand Companion.

A Location represents any physical place in Thailand.

Every Location contains geographic information.

Example fields:

* Name
* Latitude
* Longitude
* Address
* Description
* Province
* District
* Subdistrict

Every searchable item in Thailand Companion is connected to a Location.

---

# PointOfInterestType

PointOfInterestType defines what kind of POI something is.

Examples:

- Beach
- Coffee Shop
- Hospital
- School
- Restaurant
- Temple
- Park
- Market
- Immigration Office
- Coworking Space

Using PointOfInterestType allows new categories to be added without changing code.

## PointOfInterest Fields

- Id
- LocationId
- Name
- Description
- Category
- Latitude
- Longitude
- Address
- WebsiteUrl
- Phone
- OpeningHours

## POI Categories

Examples:

- Beach
- Healthcare
- Education
- Food
- Coffee
- Shopping
- Government
- Transportation
- Nature
- Religion
- Entertainment

## Why POI Exists

Most location-based information in Thailand Companion can be represented as a Point of Interest.

This keeps the system flexible.

For example, the map can easily show:

- All hospitals near a property
- All beaches near a town
- All coffee shops within walking distance
- All immigration offices in a province

The system does not need a separate table for every type of place.

# Property

Represents a real property.

Examples:

* House
* Condo
* Townhome
* Land
* Commercial Building

A Property belongs to one Location.

A Property may have many Listings.

---

# Listing

Represents a property advertisement.

Examples:

* DDProperty listing
* FazWaz listing
* Thailand Property listing

Multiple Listings may refer to the same Property.

Listings contain:

* Price
* Source
* URL
* Listing Date
* Status
* Agent

Properties remain constant while Listings may change over time.

---

# PointOfInterest replaces separate place objects

The following concepts are handled through PointOfInterest:

- Business
- Government Office
- Education
- Healthcare
- Attraction
- Transportation

# Video

Represents a YouTube video or other media related to a Location.

Examples:

* Walking tour
* Beach review
* Neighborhood guide
* Restaurant review
* Property tour

Videos belong to one Location.

---

# Review

Represents user feedback about a Location.

Examples:

* Neighborhood review
* Restaurant review
* Beach review

Reviews belong to one Location.

---

# User

Represents a registered Thailand Companion account.

Users may:

* Save Locations
* Save Properties
* Write Reviews
* Upload Photos
* Create Lists
* Subscribe to Notifications

---

# Favorite

Represents a saved Location or Property.

A User may have many Favorites.

---

# AI Recommendation

Represents AI-generated recommendations.

Examples:

* Best places to retire
* Best beach towns
* Best family neighborhoods
* Best digital nomad cities

Recommendations are generated using information from Locations and related domain objects.

---

# Future Domain Objects

The following objects are planned for future versions.

* Visa Guide
* Cost of Living Profile
* Weather
* Event
* Community
* Thai Language Lesson
* Travel Itinerary
* Moving Checklist
* Mortgage Calculator
* Currency Tracker

---

# Design Principles

* Location First
* Properties are connected to Locations
* Listings belong to Properties
* Every feature should relate back to a Location
* Designed for geographic search
* Designed for AI recommendations
* Designed for map-based exploration
* Easy to extend without redesigning the system

---

# Long-Term Goal

Thailand Companion should become the definitive platform for anyone interested in Thailand.

Instead of visiting multiple websites for properties, visas, hospitals, schools, maps, videos, and local information, users should be able to find everything they need within a single connected ecosystem.

# Country

Country represents the top-level geographic entity.

Thailand Companion will initially focus only on Thailand, but the system should remain country-aware.

Country
↓
Province
↓
District
↓
Subdistrict
↓
Location

This keeps the model flexible if the platform ever expands to Japan, Vietnam, Malaysia, or other countries.

# Coordinates and Geometry

Locations may use more than a simple latitude and longitude.

Some places are best represented as:

- Point
- Line
- Polygon

Examples:

- A coffee shop is usually a Point.
- A road or walking route may be a Line.
- A property boundary, beach area, province, or national park may be a Polygon.

PostGIS will allow Thailand Companion to support advanced geographic searches later.