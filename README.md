# NewsAPI

This solution provides a centralized web API for accessing trading news data.

## Components/Services

- NewsService: Provides methods to retrieve trading news articles based on different criteria.
- SubscriptionService: Manages subscriptions for users to receive trading news updates.

## Setup and Configuration

1. Set up the necessary dependencies and references in the projects.
2. Configure the database connection string.
3. Build and run the solution.

## Usage

1. The `NewsService` provides methods to retrieve trading news articles based on different criteria such as date, instrument, and content.
2. The `SubscriptionService` handles subscription management for users who want to receive trading news updates.
3. API endpoints can be accessed by authorized clients to retrieve news articles

## Pros and Cons

Pros:

- Provides a centralized web API for accessing and managing news data.
- Separation of concerns with distinct service components.
- Easy scalability and extensibility with API endpoints.

Cons:

- Requires additional development for API endpoints and authorization.
- May require additional setup and configuration for hosting the API.

## Task list with high-level estimations (hours or man-days):

- Set up the NewsAPI project structure and dependencies (1 day).
- Implement API endpoints for retrieving news articles (2 hours).
- Create Entities and Database connection (2 hours)
- Create repositories for news articles and subscriptions (4 hours).
- Implement the trading news service and associated endpoints (2 hours).
- Implement the subscription service and associated endpoints (2 hours).
- Test and debug the API endpoints and services (4 hours).
