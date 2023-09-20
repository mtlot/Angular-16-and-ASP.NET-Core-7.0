export class Group {
    id: number | null;
    name: string;
    
    constructor(group: Partial<Group> = {}) {
      this.id = group?.id || null;
      this.name = group?.name || '';
    }
  }