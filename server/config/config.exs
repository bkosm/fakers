# This file is responsible for configuring your application
# and its dependencies with the aid of the Mix.Config module.
#
# This configuration file is loaded before any dependency and
# is restricted to this project.

# General application configuration
use Mix.Config

config :fakers_api,
  ecto_repos: [FakersApi.Repo]

# Configures the endpoint
config :fakers_api, FakersApiWeb.Endpoint,
  url: [host: "localhost"],
  secret_key_base: "HdsCGwW3V0MUO5TwW+ibq3Q5ZKGw96HV+jRAnqSlN42cB213vGr6Pji2Wmn/BFFg",
  render_errors: [view: FakersApiWeb.ErrorView, accepts: ~w(json), layout: false],
  pubsub_server: FakersApi.PubSub,
  live_view: [signing_salt: "fRccWV+u"]

# Configures Elixir's Logger
config :logger, :console,
  format: "$time $metadata[$level] $message\n",
  metadata: [:request_id]

# Use Jason for JSON parsing in Phoenix
config :phoenix, :json_library, Jason

# Import environment specific config. This must remain at the bottom
# of this file so it overrides the configuration defined above.
import_config "#{Mix.env()}.exs"
