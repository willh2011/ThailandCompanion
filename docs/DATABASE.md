# Thailand Companion Database Design

## Overview

Thailand Companion is **not** designed as a traditional real estate website. Instead, it is built as a comprehensive platform for exploring, moving to, and living in Thailand.

The database is centered around **locations**, not properties.

This approach allows every feature—property search, AI recommendations, maps, videos, local businesses, schools, hospitals, cost of living, and community information—to share the same underlying data model.

A property is simply one type of information associated with a location rather than the primary focus of the system.

---

# Core Hierarchy

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

Every location in Thailand belongs to a Subdistrict, which belongs to a District, which belongs to a Province.

This hierarchy becomes the foundation for every search, recommendation, and map feature within Thailand Companion.

---

# Location-Centric Design

Every Location may contain or be associated with many different types of information.

```
Location
│
├── Properties
├── Hotels
├── Beaches
├── Schools
├── Hospitals
├── Restaurants
├── Coffee Shops
├── Markets
├── Parks
├── Immigration Offices
├── Temples
├── Attractions
├── Videos
├── Photos
├── Reviews
├── Cost of Living
├── Weather
├── Transportation
└── AI Insights
```

This design allows users to explore an area rather than simply searching for houses.

---

# Example

A user viewing **Cha-am** should see much more than property listings.

The Cha-am page could include:

* Interactive Map
* Current Weather
* Cost of Living
* Nearby Beaches
* Schools
* Hospitals
* Coffee Shops
* Restaurants
* Markets
* Parks
* Immigration Office
* Local Attractions
* Community Reviews
* Videos
* Properties for Sale
* Properties for Rent
* AI Area Summary

Every feature references the same Location record.

---

# Property Relationships

Properties are linked to Locations rather than existing independently.

```
Property
    │
    ▼
Location
```

This allows each property to automatically inherit information such as:

* Province
* District
* Subdistrict
* Nearby Beaches
* Nearby Hospitals
* Nearby Schools
* Nearby Restaurants
* Nearby Coffee Shops
* Nearby Parks
* Nearby Markets
* Walkability
* Cost of Living
* Transportation Options

This creates a much richer experience than a traditional property listing.

---

# Long-Term Vision

Thailand Companion aims to become the central platform for anyone interested in Thailand.

The database is intentionally designed to support future features including:

* Property Search
* AI Relocation Assistant
* Cost of Living Comparison
* Visa Guidance
* Interactive Maps
* Neighborhood Guides
* School Finder
* Hospital Finder
* Restaurant Discovery
* Beach Explorer
* YouTube Video Integration
* Community Reviews
* Thai Language Learning
* Travel Planning

Because every feature is built on the same location hierarchy, new functionality can be added without redesigning the database.

---

# Design Principles

* Location-first architecture
* Modular and extensible
* Scalable to all provinces of Thailand
* Optimized for geographic search
* Supports AI-powered recommendations
* Supports map-based exploration
* Designed for long-term growth

The goal is to build the definitive platform for exploring, relocating to, and living in Thailand—not simply another property listing website.

# Standard Entity Fields

Most database entities should include:

| Column | Type | Purpose |
|---|---|---|
| Id | int | Internal database primary key |
| PublicId | Guid | Public API identifier |
| CreatedAt | datetime | When the record was created |
| UpdatedAt | datetime | When the record was last updated |

## Why use both Id and PublicId?

`Id` is used internally for database relationships and performance.

`PublicId` is used externally in APIs and URLs so users do not see or guess internal database IDs.