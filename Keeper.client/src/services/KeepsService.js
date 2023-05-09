import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    logger.log('getting all keeps', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log("creating a keep", res.data)
    const newKeep = new Keep(res.data);
    AppState.keeps.unshift(newKeep)
    return newKeep
  }

  async setActiveKeep(keepId) {
    AppState.activeKeep = AppState.keeps.find(k => k.id == keepId)
    logger.log(AppState.activeKeep)
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    logger.log('removing keep', res.data)
    const keepIndex = AppState.keeps.findIndex((k) => k.id == keepId)
    if (keepIndex !== -1) {
      AppState.keeps.splice(keepIndex, 1)
    }
  }
}

export const keepsService = new KeepsService()