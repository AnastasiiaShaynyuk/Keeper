import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep|null} */
  activeKeep: null,
  /** @type {import('./models/Keep.js').Keep[]} */
  myKeeps: [],
  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [],
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [],
  /** @type {import('./models/Vault.js').Vault|null} */
  vault: null,
  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  vaultKeeps: [],
  /** @type {import('./models/Profile.js').Profile|Null} */
  profile: null,
});
