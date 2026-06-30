# Architecture Decisions

This document records major technical and product decisions for Thailand Companion.

---

## Decision 001: Build Thailand Companion as a location-first platform

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will be designed around locations first, not properties first.

The core hierarchy is:

Thailand → Province → District → Subdistrict → Location

### Reason

The product is not only a property website. It is a platform for exploring, moving to, and living in Thailand.

A location-first model supports:

- Property search
- Neighborhood guides
- AI relocation recommendations
- Maps
- Points of interest
- Videos
- Reviews
- Cost of living
- Visa and relocation tools

### Alternatives Considered

- Property-first architecture
- Blog/content-first architecture
- Directory/business-listing-first architecture

### Outcome

All major features should connect back to Location when possible.

---

## Decision 002: Use PointOfInterest instead of many separate place tables

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will use a PointOfInterest model for beaches, hospitals, schools, markets, restaurants, coffee shops, parks, temples, immigration offices, and similar places.

### Reason

Many useful places share the same structure:

- Name
- Category
- Description
- Latitude
- Longitude
- Address
- Phone
- Website
- Opening hours

Using PointOfInterest avoids creating many separate tables too early.

### Alternatives Considered

- Separate table for each place type
- One generic Location table only

### Outcome

PointOfInterest becomes the flexible model for map-based nearby-place searches.

---

## Decision 003: Separate Property from Listing

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

A Property represents the real-world home, condo, land, or building.

A Listing represents an advertisement for that property on a source website or by an agent.

One Property may have many Listings.

### Reason

The same property may appear on multiple websites with different prices, descriptions, agents, or photos.

This allows Thailand Companion to eventually detect duplicates and compare listing sources.

### Alternatives Considered

- Treat every listing as a separate property
- Only support manually entered properties

### Outcome

Future property search will support duplicate detection and source comparison.

---

## Decision 004: Use ASP.NET Core for the backend

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

The backend API will be built with ASP.NET Core using .NET 10.

### Reason

ASP.NET Core is professional, scalable, and useful for portfolio value.

It also supports:

- REST APIs
- Dependency injection
- Entity Framework Core
- Authentication
- Cloud deployment
- Strong typing with C#

### Alternatives Considered

- Node.js
- Python/FastAPI
- Java/Spring Boot

### Outcome

The backend will follow ASP.NET Core conventions with Controllers, Services, Interfaces, Domain, DTOs, and Data folders.

---

## Decision 005: Use Next.js for the frontend

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

The frontend will be built with Next.js, React, and TypeScript.

### Reason

Next.js provides a modern web application framework with strong support for SEO, routing, frontend performance, and future deployment options.

### Alternatives Considered

- Plain React/Vite
- Angular
- Blazor

### Outcome

The frontend will live in the frontend folder and communicate with the ASP.NET Core API.

---

## Decision 006: Use PostgreSQL with PostGIS

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will use PostgreSQL with the PostGIS extension.

### Reason

The product depends heavily on geographic search.

PostGIS supports:

- Distance searches
- Polygon searches
- Nearby places
- Map-based filtering
- Geospatial indexing

### Alternatives Considered

- SQL Server
- MySQL
- SQLite
- MongoDB

### Outcome

PostgreSQL + PostGIS will be the main production database.

---

## Decision 007: Use interface-based services

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Controllers should depend on interfaces such as IProvinceService rather than concrete service classes.

### Reason

This improves testability and makes it easier to swap implementations later.

For example:

- Fake data service
- Database service
- Cached service
- Mock service for testing

### Alternatives Considered

- Controllers directly using concrete services
- Controllers directly using database context

### Outcome

Service interfaces will live in the Interfaces folder, and implementations will live in the Services folder.

---

## Decision 008: Build vertically instead of creating many placeholders

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will build one complete feature at a time instead of creating many empty placeholder classes.

### Reason

Vertical development creates working software faster and reduces unnecessary architecture.

The preferred order is:

Province → District → Subdistrict → Location → PointOfInterest → Property → Listing

### Alternatives Considered

- Create all future classes immediately
- Build frontend first
- Build database schema for every future feature immediately

### Outcome

Each new feature should include the domain model, service, interface, controller, tests later, documentation update, and Git commit.

---

## Decision 009: Keep documentation from day one

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will maintain documentation throughout development.

Core documents:

- README.md
- ROADMAP.md
- ARCHITECTURE.md
- DATABASE.md
- DOMAIN_MODEL.md
- API.md
- STYLEGUIDE.md
- DECISIONS.md
- VISION.md

### Reason

Documentation keeps the product focused and makes the repository look professional.

### Alternatives Considered

- Add documentation later
- Keep notes outside the repository

### Outcome

Important design decisions and product direction should be documented as development continues.

---

## Decision 010: Separate Administrative Areas from Physical Locations

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will separate official geographic divisions from real-world places.

Administrative Areas:

Thailand → Province → District → Subdistrict

Physical Locations:

Locations are real-world places that belong to a Subdistrict.

### Reason

This keeps the model clean. Provinces, districts, and subdistricts are official geography. Locations are places people interact with, such as beaches, hospitals, markets, properties, and businesses.

### Outcome

Province, District, and Subdistrict will organize the system. Location will be the base for places, properties, points of interest, videos, and reviews.

---

## Decision 011: Use both internal IDs and public GUIDs

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Most entities will use both an internal integer Id and a public Guid PublicId.

### Reason

Integer IDs are efficient for database relationships. GUIDs are better for public APIs and URLs because users cannot easily guess records.

### Outcome

Internal relationships use Id. Public endpoints should eventually expose PublicId.

---

## Decision 012: Track CreatedAt and UpdatedAt

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Most entities will include CreatedAt and UpdatedAt fields.

### Reason

This supports auditing, stale listing detection, sync jobs, and future data quality checks.

### Outcome

Core entities will include CreatedAt and UpdatedAt when we move to database-backed models.

---

## Decision 013: Add Country as a top-level entity

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will include Country as the top-level geographic entity.

### Reason

The platform will focus on Thailand first, but a country-aware design keeps the model flexible and clean.

### Outcome

The hierarchy becomes Country → Province → District → Subdistrict → Location.

---

## Decision 014: Support geometry for locations

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Location-based entities should eventually support PostGIS geometry, not only latitude and longitude.

### Reason

Some geographic objects are points, while others are lines or polygons.

Examples:

- Coffee shop = point
- Road = line
- Property boundary = polygon
- Province boundary = polygon

### Outcome

Initial development may use latitude and longitude, but the database will be designed for PostGIS geometry support.

---

## Decision 015: Use PointOfInterestType

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

PointOfInterest will use PointOfInterestType rather than hardcoded category strings.

### Reason

This allows new POI categories to be added without changing code.

### Outcome

Examples include Beach, Hospital, School, Coffee Shop, Restaurant, Market, Temple, Park, and Coworking Space.

---

## Decision 016: Use BaseEntity for shared entity fields

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Most database-backed entities will inherit from BaseEntity.

### Reason

Many entities need the same fields: Id, PublicId, CreatedAt, and UpdatedAt.

### Outcome

BaseEntity will be created before building the Entity Framework Core data layer.

---

## Decision 017: Separate Domain, Entities, and DTOs

**Status:** Accepted  
**Date:** 2026-06-30

### Decision

Thailand Companion will separate business concepts, database entities, and API data transfer objects into distinct layers.

The project will use the following structure:

```
Domain/
Entities/
DTOs/
```

The `Models` folder will not be used unless a future requirement clearly justifies it.

### Reason

Separating these responsibilities keeps the architecture clean and maintainable as the project grows.

Each layer has a single responsibility:

- **Domain** defines the business concepts and rules of the application.
- **Entities** represent database objects managed by Entity Framework Core.
- **DTOs** define the data exchanged between the backend API and frontend.

Keeping these layers separate reduces coupling and makes future changes easier.

### Responsibilities

#### Domain

Contains the core business concepts of Thailand Companion.

Examples:

- Country
- Province
- District
- Subdistrict
- Location
- Property
- Listing
- PointOfInterest

Domain classes should not depend on Entity Framework Core or API serialization.

---

#### Entities

Contains database models that Entity Framework Core maps to PostgreSQL tables.

Entities may contain:

- Database relationships
- Foreign keys
- Navigation properties
- Entity Framework configuration

These classes are responsible for persistence, not business logic.

---

#### DTOs

Contains request and response objects used by the API.

Examples:

- ProvinceDto
- PropertySummaryDto
- PropertyDetailsDto
- SearchResultDto

DTOs should expose only the information required by clients and should never expose internal database implementation details.

### Alternatives Considered

- Using a single `Models` folder for everything.
- Using Entity Framework entities directly in controllers.
- Returning database entities directly to the frontend.

### Outcome

The project structure will clearly separate:

```
Domain
        ↓
Business Logic

Entities
        ↓
Database

DTOs
        ↓
API Communication
```

This architecture improves maintainability, testing, scalability, and long-term flexibility.