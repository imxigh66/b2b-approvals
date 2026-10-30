# B2B Approvals

A multi-tenant B2B web application for approving company requests (purchases, invoices, business trips, vacations).


## What is it?

Companies (tenants) use the system to create requests and send them through an approval chain defined by company rules. Every step is saved in an audit log, and approvers can approve or reject a request from their phone.

**Example:** an employee creates a request "Buy a laptop, 1200 €". The system checks the company rules (for example: up to 500 € — department manager; 500–5000 € — manager and finance; above 5000 € — also the director). Each approver gets a notification, approves or rejects with a comment, and the full history stays in the audit log.

## Key ideas

- **Multi-tenancy:** data of one company is never visible to another company.
- **Roles:** employee, manager, finance, company admin.
- **Workflow:** configurable approval steps with conditions (amount, request type).
- **Audit log:** who did what and when.
- **Background jobs:** reminders and escalations for stuck approvals.

## Tech stack

| Part | Technologies |
|---|---|
| Backend | C#, .NET 10, ASP.NET Core Web API, EF Core, PostgreSQL, JWT, Hangfire |
| Web | React (JavaScript first, then TypeScript) |
| Mobile | Kotlin (Android) |
| Testing | Playwright (TypeScript), API tests, xUnit |
| DevOps | Docker, GitHub Actions |
| Design | Figma |

## Repository structure

```
b2b-approvals/
├── backend/   # ASP.NET Core Web API
├── web/       # React web client
├── tests/     # Playwright UI and API tests
└── docs/      # Architecture, decisions, diagrams
```

## Roadmap

1. **Foundation:** repository, database, authentication, roles, tenants, CI
2. **Core:** requests, approval flow, change history
3. **Clients:** React web app, then Android app
4. **Quality:** Playwright framework, API tests, tenant isolation tests, reports in CI
5. **Advanced:** notifications, dashboard, optional AI module (invoice from PDF to request)

## Getting started

_Coming soon. Instructions will be added after the first runnable version._

Requirements for local development:

- .NET SDK 10
- Node.js 24 (LTS)
- Docker Desktop
- Git


### Database (PostgreSQL in Docker)

1. Copy the example environment file and set your own password:

   ```bash
   cp .env.example .env
   ```

   On Windows PowerShell use `copy .env.example .env`. Then open `.env` and change `POSTGRES_PASSWORD`. Never commit the `.env` file.

2. Start the database:

   ```bash
   docker compose up -d
   ```

3. Check that the container is healthy:

   ```bash
   docker compose ps
   ```

4. Stop the database (the data is kept in a Docker volume):

   ```bash
   docker compose down
   ```

   To delete the data as well and start from scratch, use `docker compose down -v`.

Default connection settings (from `.env.example`): host `localhost`, port `5432`, database `b2b_approvals`, user `b2b_user`.


## Testing

_Coming soon._ Tests will run automatically in GitHub Actions on every pull request.

   ## Git workflow

   - `main` is the only permanent branch.
   - One task = one branch (`feature/SCRUM-xx-short-name`) = one pull request.
   - Commit messages start with the Jira key, for example `SCRUM-19: update README`.
   - Merge to `main` only after a review.

