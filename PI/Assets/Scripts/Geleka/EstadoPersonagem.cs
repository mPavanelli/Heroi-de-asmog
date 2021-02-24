using UnityEngine;

public abstract class EstadoPersonagem {

    GameObject gobj;

    public EstadoPersonagem(GameObject gobj)
    {
        this.gobj = gobj;
    }

    public abstract void EstadoUpdate();

    public abstract void EstadoFixedUpdate();

    public abstract void LeInput();

    public abstract int EstaNoChaoParede();

    public abstract void AplicaMovimento();
}
